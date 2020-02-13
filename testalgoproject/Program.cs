using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static testalgoproject.BigInteger1;

namespace testalgoproject
{
    class Program
    {
        static void Main(string[] args)
        {
           
            BigInteger1 bigInteger = new BigInteger1();
            



            int cases;
            string M, E, N,type,res;
            StreamReader sr;
            StreamWriter sw;
            FileStream FR;
            FileStream FW;
            Console.WriteLine("\n[1] integers \n[2] strings(bonus)");
            int ch =  int.Parse(Console.ReadLine());
            if (ch == 1)
            {
            A: Console.WriteLine("\n[1] sample test case \n[2] compelete test case \n[3] Exit");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {

                    FR = new FileStream("SampleRSA.txt", FileMode.Open);
                    sr = new StreamReader(FR);
                    FW = new FileStream("sampleOutput.txt", FileMode.Create);
                    sw = new StreamWriter(FW);
                    cases = int.Parse(sr.ReadLine());

                    for (int i = 0; i < cases; i++)
                    {

                        N = sr.ReadLine();
                        E = sr.ReadLine();
                        M = sr.ReadLine();
                        type = sr.ReadLine();

                        if (type == "0")
                        {
                            res = bigInteger.encrypt(M, E, N);

                        }
                        else
                        {
                            res = bigInteger.decrypt(M, E, N);
                        }

                        sw.WriteLine(res);


                    }


                    sr.Close();
                    sw.Close();
                    FR.Close();
                    FW.Close();
                    Console.WriteLine("Done !!!");
                }
                else if (choice == 2)
                {
                    FR = new FileStream("TestRSA.txt", FileMode.Open);
                    sr = new StreamReader(FR);
                    FW = new FileStream("compeleteOutput.txt", FileMode.Create);
                    sw = new StreamWriter(FW);
                    cases = int.Parse(sr.ReadLine());
                    int time, stime, ftime,times;
                    for (int i = 0; i < cases; i++)
                    {
                        stime = int.Parse(Environment.TickCount.ToString());
                        N = sr.ReadLine();
                        E = sr.ReadLine();
                        M = sr.ReadLine();
                        type = sr.ReadLine();

                        if (type == "0")
                        {
                            res = bigInteger.encrypt(M, E, N);

                        }
                        else
                        {
                            res = bigInteger.decrypt(M, E, N);
                        }
                        ftime = int.Parse(Environment.TickCount.ToString());
                        time = (ftime - stime)/1000;
                        times = (ftime - stime) % 1000;

                        Console.WriteLine(time+" Seconds and "+times + "Milliseconds");
                        sw.WriteLine(res);


                    }


                    sr.Close();
                    sw.Close();
                    FR.Close();
                    FW.Close();
                    Console.WriteLine("Done !!!");
                }

                else if (choice == 3) { return; }
                else
                {
                    Console.WriteLine("Wrong entry");
                    goto A;

                }
                goto A;
            }
            else {

                Console.WriteLine("enter a string");
                 
                string sb = Console.ReadLine();



                string ascii = bigInteger.convertascii(sb);
                Console.WriteLine(ascii);
                string enc = bigInteger.encrypt(ascii, "22397637870882549517368596622641300924171095020557753582603446902846197377658196974714575577237681892436409853219169457", "47594980475625417724408267823112764463863576918685226363032787239910118740004860624166859668486833021538759738968887527");
                Console.WriteLine(enc);
                string dec = bigInteger.encrypt(enc, "17", "47594980475625417724408267823112764463863576918685226363032787239910118740004860624166859668486833021538759738968887527");

                string fromascii = "";
                if (dec.Length % 3 == 0)
                {
                    Console.WriteLine(dec);
                    fromascii = bigInteger.convertfromascii(dec);

                }
                else
                {
                    Console.WriteLine("0" + dec);
                    fromascii = bigInteger.convertfromascii("0" + dec);
                }
                Console.WriteLine(fromascii);


            }
        }



    }

    }



