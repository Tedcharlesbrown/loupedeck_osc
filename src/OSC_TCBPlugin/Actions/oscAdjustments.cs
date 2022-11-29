namespace Loupedeck.OSC_TCBPlugin.Actions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using SharpOSC;

    public class oscAdjustments : PluginDynamicCommand
    {

        public oscAdjustments()
            : base()
        {
            // Profile actions do not belong to a group in the current UI, they are on the top level
            this.DisplayName = "Send OSC"; // so this will be shown as "group name" for parameterized commands
            this.GroupName = "Not used";

            this.MakeProfileAction("text;Message:");

        }

        protected override void RunCommand(String actionParameter)
        {
            System.Diagnostics.Debug.WriteLine(parse_actionParameter(actionParameter)[0]);

            // var message = new SharpOSC.OscMessage(actionParameter, "hello world");
            // var sender = new SharpOSC.UDPSender("127.0.0.1", 55555);
            var message = new SharpOSC.OscMessage(parse_actionParameter(actionParameter)[2], parse_actionParameter(actionParameter)[3]);
            var sender = new SharpOSC.UDPSender(parse_actionParameter(actionParameter)[0], Int16(parse_actionParameter(actionParameter)[1]));
            sender.Send(message);

        }

        public String[] parse_actionParameter(String actionParameter)
        {
            String ip_address = "";
            String port_number = "";
            String address = "";
            String argument = "";

            String delim_ip_address = ":";
            String delim_port_number = "|";
            String delim_address = " ";

            // PARSE IP ADDRESS
            Console.WriteLine(actionParameter);
            if (actionParameter.Contains(delim_ip_address))
            {
                int start_index = actionParameter.IndexOf(delim_ip_address);
                ip_address = actionParameter.Substring(0, start_index);
                System.Diagnostics.Debug.WriteLine("IP ADDRESS = " + ip_address.ToString());
            }
            // PARSE PORT NUMBER
            if (actionParameter.Contains(delim_port_number))
            {
                int start_index = actionParameter.IndexOf(delim_ip_address) + 1;
                int end_index = actionParameter.IndexOf(delim_port_number) - start_index;

                port_number = actionParameter.Substring(start_index, end_index);
                System.Diagnostics.Debug.WriteLine("PORT NUMBER = " + port_number.ToString());
            }
            // PARSE ADDRESS
            if (actionParameter.Contains(delim_port_number))
            {
                int start_index = actionParameter.IndexOf(delim_port_number) + 1;
                int end_index = actionParameter.IndexOf(delim_address) - start_index;
                address = actionParameter.Substring(start_index, end_index);
                System.Diagnostics.Debug.WriteLine("ADDRESS = " + address.ToString());

            }

            // PARSE ARGUMENTS
            if (actionParameter.Contains(delim_port_number))
            {
                int start_index = actionParameter.IndexOf(delim_address) + 1;
                argument = actionParameter.Substring(start_index);
                System.Diagnostics.Debug.WriteLine("ARGUMENT = " + argument.ToString());

            }

            String[] actionParameters = {ip_address,port_number,address,argument};

            return actionParameters;
        }
    }

}
