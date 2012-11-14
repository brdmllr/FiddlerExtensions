using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiddler;
using FiddlerExtensions.Exporters.ExtensionMethods;

namespace FiddlerExtensions.Exporters
{
    [ProfferFormat("Comma Separated Values", "")]
    public class CsvExporter : ISessionExporter
    {
        private readonly string delimiter = ",";

        bool ISessionExporter.ExportSessions(string sExportFormat, Session[] oSessions, Dictionary<string, object> dictOptions, EventHandler<ProgressCallbackEventArgs> evtProgressNotifications)
        {
            string fileName = string.Empty;

            fileName = Utilities.ObtainSaveFilename("Export As " + sExportFormat, "CSV Files (*.csv)|*.csv");

            if (String.IsNullOrEmpty(fileName))
            {
                return false;
            }

            try
            {
                StringBuilder csvOutput = new StringBuilder();

                //Header line
                csvOutput.AppendDelimiter("#", delimiter);
                csvOutput.AppendDelimiter("Result", delimiter);
                csvOutput.AppendDelimiter("Host", delimiter);
                csvOutput.Append("Path");

                csvOutput.AppendLine();


                //Loop through sessions
                foreach (Session session in oSessions)
                {
                    csvOutput.AppendDelimiter(session.id.ToString(), delimiter);
                    csvOutput.AppendDelimiter(session.responseCode.ToString(), delimiter);
                    csvOutput.AppendDelimiter(session.hostname, delimiter);
                    csvOutput.Append(session.PathAndQuery);

                    /*
                    public DateTime ClientBeginRequest;
                    public DateTime ClientBeginResponse;
                    public DateTime ClientConnected;
                    public DateTime ClientDoneRequest;
                    public DateTime ClientDoneResponse;
                    public int DNSTime;
                    public DateTime FiddlerBeginRequest;
                    public DateTime FiddlerGotRequestHeaders;
                    public DateTime FiddlerGotResponseHeaders;
                    public int GatewayDeterminationTime;
                    public int HTTPSHandshakeTime;
                    public DateTime ServerBeginResponse;
                    public DateTime ServerConnected;
                    public DateTime ServerDoneResponse;
                    public DateTime ServerGotRequest;
                    public int TCPConnectTime;
                     */
                }

                FiddlerApplication.Log.LogString(csvOutput.ToString());

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        void IDisposable.Dispose()
        {
            return;
        }
    }
}
