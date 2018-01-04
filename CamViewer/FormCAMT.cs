using System;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using SevenZip;
using System.Collections;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;
using System.Configuration;
using System.Xml.Serialization;

namespace CamViewer
{
    public partial class FormCAMT : Form
    {
        public FormCAMT()
        {
            InitializeComponent();

            documentViewer.DocumentSource = new ReportCAMT();

            treeListFiles.BeginUpdate();
            TreeListColumn nameCol = treeListFiles.Columns.Add();
            nameCol.Caption = "Datei";
            nameCol.OptionsColumn.AllowEdit = false;
            nameCol.VisibleIndex = 0;

            TreeListColumn fileCol = treeListFiles.Columns.Add();
            fileCol.Caption = "Filename";
            fileCol.OptionsColumn.AllowEdit = false;
            fileCol.Visible = false;

            treeListFiles.OptionsView.ShowRoot = false;
            treeListFiles.EndUpdate();

            TreeListNode parentForRootNodes = null;
            LoadFiles(parentForRootNodes);
        }

        private void LoadFiles(TreeListNode parentForRootNodes)
        {
            string sourcepath = ConfigurationManager.AppSettings["Source"];
            string sourcedirectory = Path.GetDirectoryName(sourcepath);
            DirectoryInfo di = new DirectoryInfo(sourcedirectory);
            foreach (FileInfo fi in di.GetFiles(Path.GetFileName(sourcepath)))
            {
                treeListFiles.AppendNode(new object[] { fi.Name, fi.FullName }, parentForRootNodes);
            }
        }

        private void TreeListFiles_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            TreeListNode tn = e.Node;
            object obj = tn.GetValue(1);

            DataTable dt = LoadCAMTFile(obj.ToString());

            ((ReportCAMT)documentViewer.DocumentSource).DataSource = dt;
            ((ReportCAMT)documentViewer.DocumentSource).CreateDocument();
        }

        private static DataTable LoadCAMTFile(string sourceFile)
        {
            Hashtable picfiles = new Hashtable();
            XmlDocument xml = new XmlDocument();

            using (SevenZip.SevenZipExtractor extractorgz = new SevenZip.SevenZipExtractor(sourceFile))
            {
                byte[] gz = null;
                MemoryStream msgz = new MemoryStream();
                extractorgz.ExtractFile(0, msgz);
                msgz.Position = 0;


                using (SevenZip.SevenZipExtractor extractortar = new SevenZipExtractor(msgz))
                {
                    foreach (string fn in extractortar.ArchiveFileNames)
                    {
                        MemoryStream mstar = new MemoryStream();
                        extractortar.ExtractFile(fn, mstar);
                        mstar.Position = 0;

                        if (fn.ToUpper().EndsWith(".XML"))
                        {
                            xml = new XmlDocument();
                            xml.Load(mstar);

                        }
                        else
                        {
                            byte[] tiff = mstar.ToArray();
                            picfiles.Add(fn, tiff);
                        }
                        mstar.Close();
                        Console.WriteLine(fn);
                    }
                }
                msgz.Close();
            }

            // Document class created using XSD.EXE from Microsoft SDKs to generate class from XSD file!
            // https://docs.microsoft.com/en-us/dotnet/standard/serialization/xml-schema-def-tool-gen
            XmlSerializer ser = new XmlSerializer(typeof(Document));
            XmlReader xmlReader = new XmlNodeReader(xml);
            Document myDoc = ser.Deserialize(xmlReader) as Document;

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Image", typeof(byte[])));
            dt.Columns.Add(new DataColumn("AcctIdIBAN", typeof(string)));
            dt.Columns.Add(new DataColumn("AcctOwnrNm", typeof(string)));
            dt.Columns.Add(new DataColumn("NtryAmt", typeof(string)));

            foreach (var stmt in myDoc.BkToCstmrStmt.Stmt)
            {
                foreach (var ntry in stmt.Ntry)
                {
                    foreach (var ntrydtls in ntry.NtryDtls)
                    {
                        foreach (var txdtls in ntrydtls.TxDtls)
                        {
                            DataRow dr = dt.NewRow();
                            string AMT = txdtls.Amt.Value.ToString();
                            if (txdtls.Refs != null && txdtls.Refs.Prtry != null)
                            {
                                foreach (var prtry in txdtls.Refs.Prtry)
                                {
                                    if (prtry.Ref != null)
                                    {
                                        foreach (string k in picfiles.Keys)
                                        {
                                            if (k.Contains(prtry.Ref))
                                            {
                                                dr["Name"] = k;
                                                dr["Image"] = picfiles[k];
                                            }
                                        }
                                    }
                                }
                            }
                            dr["AcctIdIBAN"] = (txdtls.RltdPties == null || txdtls.RltdPties.DbtrAcct == null) ? string.Empty : txdtls.RltdPties.DbtrAcct.Id.Item;
                            dr["AcctOwnrNm"] = (txdtls.RltdPties == null || txdtls.RltdPties.Dbtr == null)
                                ? string.Empty
                                : txdtls.RltdPties.Dbtr.Nm;
                            dr["NtryAmt"] = AMT;

                            if (!string.IsNullOrWhiteSpace(dr["Name"]+ string.Empty))
                            {
                                dt.Rows.Add(dr);
                            }
                        }
                    }
                }
            }
            return dt;
        }

        // load cam file into datatable to display
        private static DataTable LoadCAMFile(string source_file)
        {
            Hashtable picfiles = new Hashtable();
            XmlDocument xml = new XmlDocument();

            using (SevenZip.SevenZipExtractor extractorgz = new SevenZip.SevenZipExtractor(source_file))
            {
                byte[] gz = null;
                MemoryStream msgz = new MemoryStream();
                extractorgz.ExtractFile(0, msgz);
                msgz.Position = 0;


                using (SevenZip.SevenZipExtractor extractortar = new SevenZipExtractor(msgz))
                {
                    foreach (string fn in extractortar.ArchiveFileNames)
                    {
                        MemoryStream mstar = new MemoryStream();
                        extractortar.ExtractFile(fn, mstar);
                        mstar.Position = 0;

                        if (fn.ToUpper().EndsWith(".XML"))
                        {
                            xml = new XmlDocument();
                            xml.Load(mstar);

                        }
                        else
                        {
                            byte[] tiff = mstar.ToArray();
                            picfiles.Add(fn, tiff);
                        }
                        mstar.Close();
                        Console.WriteLine(fn);
                    }
                }
                msgz.Close();
            }

            // Document class created using XSD.EXE from Microsoft SDKs to generate class from XSD file!
            // https://docs.microsoft.com/en-us/dotnet/standard/serialization/xml-schema-def-tool-gen
            XmlSerializer ser = new XmlSerializer(typeof(Document));
            XmlReader xmlReader = new XmlNodeReader(xml);
            Document myDoc = ser.Deserialize(xmlReader) as Document;
           
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Image", typeof(byte[])));
            dt.Columns.Add(new DataColumn("AcctIdIBAN", typeof(string)));
            dt.Columns.Add(new DataColumn("AcctOwnrNm", typeof(string)));
            dt.Columns.Add(new DataColumn("NtryAmt", typeof(string)));

            foreach (var stmt in myDoc.BkToCstmrStmt.Stmt)
            {
                foreach(var ntry in stmt.Ntry)
                {
                    foreach(var ntrydtls in ntry.NtryDtls)
                    {
                        foreach(var txdtls in ntrydtls.TxDtls)
                        {
                            DataRow dr = dt.NewRow();
                            string AMT = txdtls.Amt.Value.ToString();
                            if (txdtls.Refs != null && txdtls.Refs.Prtry != null)
                            {
                                foreach (var prtry in txdtls.Refs.Prtry)
                                {
                                    if (prtry.Ref != null)
                                    {
                                        foreach (string k in picfiles.Keys)
                                        {
                                            if (k.Contains(prtry.Ref))
                                            {
                                                dr["Name"] = k;
                                                dr["Image"] = picfiles[k];
                                            }
                                        }
                                    }
                                }
                            }
                            dr["AcctIdIBAN"] = txdtls.RltdPties.DbtrAcct.Id.Item;
                            dr["AcctOwnrNm"] = txdtls.RltdPties.Dbtr.Nm;
                            dr["NtryAmt"] = AMT;
                            dt.Rows.Add(dr);
                        }
                    }
                }
            }           
            return dt;
        }
        
    }
}
