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

        String delim_ip_address = ":";
        String delim_port_number = "|";
        String delim_address = " ";

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
            //System.Diagnostics.Debug.WriteLine(parse_actionParameter(actionParameter)[0]);

            //var message = new SharpOSC.OscMessage(actionParameter, "hello world");
            //var sender = new SharpOSC.UDPSender("127.0.0.1", 55555);
            parse_osc_arguments(actionParameter);
            var message = new SharpOSC.OscMessage(parse_osc_address(actionParameter), 1);
            var sender = new SharpOSC.UDPSender(parse_ip_address(actionParameter), parse_port_number(actionParameter));
            sender.Send(message);

        }


        public String parse_ip_address(String actionParameter)
        {
            String ip_address = "127.0.0.1";

            if (actionParameter.Contains(this.delim_ip_address))
            {
                int start_index = actionParameter.IndexOf(this.delim_ip_address);
                ip_address = actionParameter.Substring(0, start_index);
                //System.Diagnostics.Debug.WriteLine("IP ADDRESS = " + ip_address.ToString());
            }

            return ip_address;
        }

        public Int32 parse_port_number(String actionParameter)
        {
            Int32 port_number = 55555;

            if (actionParameter.Contains(this.delim_port_number))
            {
                int start_index = actionParameter.IndexOf(this.delim_ip_address) + 1;
                int end_index = actionParameter.IndexOf(this.delim_port_number) - start_index;

                port_number = Int32.Parse(actionParameter.Substring(start_index, end_index));
                //System.Diagnostics.Debug.WriteLine("PORT NUMBER = " + port_number.ToString());
            }

            return port_number;
        }

        public String parse_osc_address(String actionParameter)
        {

            String address = "";

            if (actionParameter.Contains(this.delim_port_number))
            {
                int start_index = actionParameter.IndexOf(this.delim_port_number) + 1;
                int end_index = actionParameter.IndexOf(this.delim_address) - start_index;
                address = actionParameter.Substring(start_index, end_index);
                //System.Diagnostics.Debug.WriteLine("ADDRESS = " + address.ToString());

            }

            return address;
        }

        public void parse_osc_arguments(String actionParameter)
        {
            
            String arguments = "";

            if (actionParameter.Contains(this.delim_port_number))
            {
                int start_index = actionParameter.IndexOf(this.delim_address) + 1;
                arguments = actionParameter.Substring(start_index);
                System.Diagnostics.Debug.WriteLine("ARGUMENT = " + arguments.ToString());
            }

            bool found_type = false;

            try
            {
                Int32.Parse(arguments).GetType();
                found_type = true;
                System.Diagnostics.Debug.WriteLine("ARGUMENT IS INT");
            }
            catch (FormatException)
            {
                System.Diagnostics.Debug.WriteLine("ARGUMENT IS NOT INT");
            }

            try
            {
                float.Parse(arguments).GetType();
                found_type = true;
                System.Diagnostics.Debug.WriteLine("ARGUMENT IS FLOAT");
            }
            catch (FormatException)
            {
                System.Diagnostics.Debug.WriteLine("ARGUMENT IS NOT FLOAT");
            }

            if (arguments is String && found_type == false)
            {
                System.Diagnostics.Debug.WriteLine("ARGUMENT IS STRING");
            }

        }
    }
}
