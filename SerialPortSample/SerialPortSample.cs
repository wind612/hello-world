using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This example demonstrates the use of the TimeoutException 
// exception in conjunction with the SerialPort class.
namespace SerialPortSample
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            try
            {
                // Set the COM1 serial port to speed = 9600 baud, parity = None, 
                // data bits = 8, stop bits = 1.
                SerialPort sp = new SerialPort("COM1",
                                9600, Parity.None, 8, StopBits.One);
                // Timeout after 2 seconds.
                sp.ReadTimeout = 5000;
                sp.Open();

                // Read until either the default newline termination string 
                // is detected or the read operation times out.
                input = sp.ReadLine();

                sp.Close();

                // Echo the input.
                Console.WriteLine(input);
            }

            // Only catch timeout exceptions.
            catch (TimeoutException e)
            {
                Console.WriteLine(e);
            }

            Console.ReadLine();
        }

    }
}

/*
This example produces the following results:

(Data received at the serial port is echoed to the console if the 
read operation completes successfully before the specified timeout period 
expires. Otherwise, a timeout exception like the following is thrown.)

System.TimeoutException: The operation has timed-out.
   at System.IO.Ports.SerialStream.ReadByte(Int32 timeout)
   at System.IO.Ports.SerialPort.ReadOneChar(Int32 timeout)
   at System.IO.Ports.SerialPort.ReadTo(String value)
   at System.IO.Ports.SerialPort.ReadLine()
   at Sample.Main()
*/

