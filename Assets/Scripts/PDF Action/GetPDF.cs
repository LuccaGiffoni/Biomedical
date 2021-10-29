using System;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace PDFBuilder
{
    public class GetPDF : MonoBehaviour
    {
        // Image upload
        public static byte[] bytesArray = null;
        public static byte[] Imagem = null;

        private string station = "32";
        private string equipment = "103";
        private string line = "15";

        private static int ID;
        private static int StationID;
        private static int EquipmentID;
        private static string Name;
        private static string Version;
        private static string LastUpdate;

        public static string documentName;

        public string Station
        {
            get { return station; }
            set { station = value; }
        }

        public string Equipment
        {
            get { return equipment; }
            set { equipment = value; }
        }

        public string Line
        {
            get { return line; }
            set { line = value; }
        }

        public List<string> pdfName = new List<string>();

        public void DownloadPDF()
        {
            try
            {
                pdfName.Clear();

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                // Change the variables above with these values when testing
                builder.DataSource = ConnectionString.DataSource;
                builder.UserID = ConnectionString.UserID;
                builder.Password = ConnectionString.Password;
                builder.InitialCatalog = ConnectionString.InitialCatalog;
;
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();

                    // SQL Command through C#
                    String sql = "SELECT TOP 8 DATALENGTH(pdfvarbinary), pdfvarbinary, pdfname FROM archives";

                    // Reading all rows from the first line
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    // Assigning to variables
                                    Name = reader.GetString(2);
                                    pdfName.Add(Name);

                                    // Version = reader.GetString(3);
                                    // LastUpdate = reader.GetString(3);

                                    if (!reader.IsDBNull(1))
                                    {
                                        var longVar = reader.GetInt64(0);
                                        longVar = 10;

                                        // Trying to convert the VARBINARY to a array of bytes
                                        try
                                        {
                                            int ndx = reader.GetOrdinal("pdfvarbinary");

                                            if (!reader.IsDBNull(ndx))
                                            {
                                                long size = reader.GetBytes(ndx, 0, null, 0, 0);  //get the length of data
                                                bytesArray = new byte[size];

                                                int bufferSize = 1024;
                                                long bytesRead = 0;
                                                int curPos = 0;
                                                int i = 0;

                                                while (bytesRead < size)
                                                {
                                                    i++;
                                                    bytesRead += reader.GetBytes(ndx, curPos, bytesArray, curPos, bufferSize);
                                                    curPos += bufferSize;
                                                }

                                                try
                                                {
                                                    string path = "Assets/StreamingAssets/" + Name + ".pdf";
                                                    System.IO.File.WriteAllBytes(path, bytesArray);
                                                }
                                                catch (Exception e)
                                                {
                                                    Debug.Log(e.ToString());
                                                }

                                            }
                                        }
                                        catch (SqlException e)
                                        {
                                            Debug.Log(e.ToString());
                                        }
                                        finally
                                        {
                                            Debug.Log("O PDF foi salvo com sucesso");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }

            for (int i = 0; i < pdfName.Count; i++)
            {
                if (pdfName[i] != null)
                {
                    Debug.Log(pdfName[i]);
                    string buttonName = "Button" + i.ToString();
                    GameObject button = GameObject.Find(buttonName);
                    button.GetComponentInChildren<TextMeshPro>().text = pdfName[i];
                }
            }
        }
    }

}
