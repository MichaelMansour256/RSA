using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace testalgoproject
{
  
    class BigInteger1
    {
            public string encrypt(string m, string e, string n) {
               
                string encmsg = divBigInt(m,n).R;        //o(n)
                encmsg = modOfPowerBigInt(encmsg, e, n); // o(n^1.58 log (p))
                encmsg = divBigInt(encmsg, n).R;         //o(n)

                return encmsg;                           //o(1)
            }
            public string decrypt(string em, string d, string n)
            {
                string decmsg = divBigInt(em, n).R; //o(n)
                decmsg = modOfPowerBigInt(decmsg, d, n);// o(n^1.58 log (p))
                decmsg = divBigInt(decmsg, n).R;    //o(n)

                return decmsg;                      //o(1)
            }
            public string modOfPowerBigInt(string B, string P, string M)
            {

                    if (B == "0")  //o(1)
                    {
                        return "0"; //o(1)
                    }

                    if (P == "0" && M != "1") //o(1)
                    {
                        return "1";    //o(1)
                    }
                    string newpower; //o(1)
                    string X;//o(1)
                    string y;//o(1)
                    string rem = divBigInt(P, "2").R; //o(n)
                    if (rem == "0") //o(n^1.58)
                    {
                        newpower = divBigInt(P, "2").Q;  //o(n) 
                        X = modOfPowerBigInt(B, newpower, M); //rec
                        y = multBigInt(X, X);//o(n^1.58)
                        X = divBigInt(y, M).R; //o(n)
                        return divBigInt(X, M).R;  //o(n)
                    }
                    else
                    {
                        newpower = subBigInt(P, "1"); //o(n)
                        newpower = divBigInt(newpower, "2").Q;//o(n)
                        X = modOfPowerBigInt(B, newpower, M);//rec
                        X = multBigInt(X, X);//o(n^1.58)
                        y = multBigInt(X, B);//o(n^1.58)
                        X = divBigInt(y, M).R;//O(n)
                        return divBigInt(X,M).R;//o(n)
                    }

            

            }
            public struct s {
               
               public string Q;
                public string R;

            }
            public bool is_smaller(string str1, string str2)
            {

                if (str1.Length < str2.Length)//o(1)
                {
                    return true; // O(1)
                }
                else if (str1.Length > str2.Length) { //O(1)

                    return false; //O(1)
                }
                else
                {
                    for (int i = 0; i < str1.Length; i++) { //O(n)
                        if (str1[i] < str2[i])
                        {
                            return true;//O(1)

                        }
                        else if (str1[i] > str2[i])//O(1)
                        {
                            return false;//O(1)

                        }

                    }
                    return false; //O(1)

                }
               
            }
            public s divBigInt(string X, string Y)
            {//o(n)
               
           
           
                if (is_smaller(X,Y))//O(N)
                {
                    s s1; //O(1)
                    s1.Q = "0";//O(1)
                    s1.R =X;//O(1)

                    return s1;//O(1)
                }
                string yn = addBigInt(Y, Y);//O(N)
                s  s2 = divBigInt(X,yn);//rec O(N)
                s2.Q = addBigInt(s2.Q, s2.Q); //O(N)

                if (is_smaller(s2.R,Y)) //O(N)
                {

                    return s2;//O(1)
                }
                else {
                    s2.Q = addBigInt(s2.Q, "1");//O(N)
                    s2.R = subBigInt(s2.R,Y);//O(N)
                    return s2;//O(1)
                }

                
            }
            public string MakeShifting(string str, int n)
            {
                
                StringBuilder sb = new StringBuilder(str);//O(1)
  
                    for (int i = 0; i < n; i++)//O(n)
                {
                        sb.Append('0');//o(1)
                    } // order n (n equal stepnumber) max value equal number length
                     return sb.ToString();
            }

            public string multBigInt(string X, string Y)
            {
                    
                    Boolean sign = false;
                    if (X[0] == '-' && Y[0] == '-') //o(n)
                    {
                        X = X.Substring(1, X.Length - 1); //o(n)
                        Y = Y.Substring(1, Y.Length - 1); //o(n)

                    }
                    else if (X[0] == '-')   //o(n)
                    {
                       
                        X = X.Substring(1, X.Length - 1); //o(N)
                        sign = true;//o(1)

                    }
                    else if (Y[0] == '-') //o(n)
                    {
                        Y = Y.Substring(1, Y.Length - 1); //o(N)
                        sign = true;//o(1)
                    }
                   
                    int lenX = X.Length;//o(1)
                    int lenY = Y.Length;//o(1)
                    int n = lenX;//o(1)
                    StringBuilder sb;//o(1)
                    if (lenX < lenY)//o(n)
                    {
                        sb = new StringBuilder(X);
                        for (int i = 0; i < lenY - lenX; i++)//o(n)
                            sb.Insert(0,"0");//o(1)
                        n = lenY;//o(1)
                        X = sb.ToString();//o(n)
                    }
                    else if (lenX > lenY)//o(n)
                {
                        sb =new StringBuilder(Y);//o(1)
                    for (int i = 0; i < lenX - lenY; i++)//o(n)
                        sb.Insert(0, "0");//o(1)
                        n = lenX;//o(1)
                        Y = sb.ToString();//o(n)
                }

                    


                    if (n == 1)//o(1)
                {
                        return (int.Parse(X) * int.Parse(Y)).ToString();//o(1)
                }

                    
                    int fh = n / 2;//o(n)
                int sh = (n - fh);//o(n)
                 //a
                string Xl = X.Substring(0, fh);//o(n)
                   //b
                string Xr = X.Substring(fh, sh);//o(n)

                //c
                string Yl = Y.Substring(0, fh);//o(n)
                //d
                string Yr = Y.Substring(fh, sh);//o(n)

                //ac
                string P1 = multBigInt(Xl, Yl);//rec
                                               //bd
                string P2 = multBigInt(Xr, Yr);//rec
                    //(a+b)*(c+d)
                string P3 = multBigInt(addBigInt(Xl, Xr), addBigInt(Yl, Yr));//rec
                string shift = MakeShifting(P1, 2 * (n - n / 2));//o(n)
                string firstpart =addBigInt(shift, P2);//o(n)
                string secsub = addBigInt(P1, P2);//o(n)
                string firshift = subBigInt(P3, secsub);//o(n)
                string secpart = MakeShifting(firshift, n - (n / 2));//o(n)
                //bd*10^n+ 10^n/2 ac + ((a+b)*(c+d)-ac-bd) 
                string mul = addBigInt(firstpart,secpart);//o(n)
                int count = 0;//o(n)
                              //if there is any zeros on left remove it
                while (count < mul.Length - 1)//o(n)
                {
                        if (mul[count] == '0')//o(1)
                    {
                            count++;//o(1)

                    }
                        else
                            break;//o(1)



                } 
                   
                    mul = mul.Substring(count, mul.Length - count);//o(n)
                if (sign)//o(n)
                {
                        mul = '-' + mul;//o(n)
                }
                    return mul;//o(n)
            }

            public string subBigInt(string num1, string num2)
            {
                //subtract two big numbers
                // check if the second number is big than first swap them and take a flag
                int lenX = num1.Length;//O(1)
                int lenY = num2.Length;//O(1)
                int n = lenX;//O(1)
                StringBuilder sm;//O(1)
                if (lenX < lenY)//O(N)
                {
                    sm = new StringBuilder(num1);//O(1)
                    for (int i = 0; i < lenY - lenX; i++)//O(n)
                        sm.Insert(0, "0");//O(1)
                    n = lenY;//O(1)
                    num1 = sm.ToString();//O(N)
                }
                else if (lenX > lenY)//O(N)
                {
                    sm = new StringBuilder(num2);//O(1)
                    for (int i = 0; i < lenX - lenY; i++)//O(N)
                        sm.Insert(0, "0");//O(1)
                    n = lenX;//O(1)
                    num2 = sm.ToString();//O(N)
                }
                // int max = num1.Length < num2.Length ? num2.Length : num1.Length;

                int borrow = 0;//O(1)
                int[] dif = new int[n + 1];//O(1)
                char[] num11 = num1.ToCharArray();//O(n)
                char[] num12 = num2.ToCharArray();//O(n)
                Array.Reverse(num11);//O(n)
                Array.Reverse(num12);//O(n)
                for (int k = 0; k < n; k++)//O(n)
                {
                    if ((int)(num11[k] - 48) - borrow < ((int)(num12[k] - 48)))//O(1)
                    {
                        dif[k] = (((int)(num11[k] - 48)) - borrow + 10) - ((int)(num12[k] - 48));//O(1)
                        borrow = 1;//O(1)
                    }
                    else//O(1)
                    {
                        dif[k] = (((int)(num11[k] - 48)) - borrow) - ((int)(num12[k] - 48));//O(1)
                        borrow = 0;//O(1)

                    }
                }
                
                
                StringBuilder sb = new StringBuilder();//O(1)


                for (int k = n; k >= 0; k--)//O(n)
                {
                    sb.Append(dif[k]);//O(1)

                }
                int count = 0;//O(1)
                while (count < sb.Length - 1)//O(n)
                {
                    if (sb[count] == '0')//O(1)
                    {
                        count++;//O(1)

                    }
                    else
                        break;//O(1)



                }
                
                sb = sb.Remove(0, count);//O(n)

                return sb.ToString();//O(n)
            }
            public string addBigInt(string num1, string num2)
            {

                int lenX = num1.Length;//O(1)
                int lenY = num2.Length;//O(1)
                int n = lenX;//O(1)
                StringBuilder sm;//O(1)
                if (lenX < lenY)//O(n)
                {
                    sm = new StringBuilder(num1);//O(1)
                    for (int i = 0; i < lenY - lenX; i++)//O(n)
                        sm.Insert(0, "0");//O(1)
                    n = lenY;//O(1)
                    num1 = sm.ToString();//O(1)
                }
                else if (lenX > lenY)//O(n)
                {
                    sm = new StringBuilder(num2);//O(1)
                    for (int i = 0; i < lenX - lenY; i++)//O(n)
                        sm.Insert(0, "0");//O(1)
                    n = lenX;//O(1)
                    num2 = sm.ToString();//O(1)
                }
                int max = n;//O(1)

                int carry = 0;//O(1)
                int[] sum = new int[max + 1];//O(1)
                char[] num11 = num1.ToCharArray();//O(n)
                char[] num12 = num2.ToCharArray();//O(n)
                Array.Reverse(num11);//O(n)
                Array.Reverse(num12);//O(n)
                for (int k = 0; k < max; k++)//O(n)
                {
                    sum[k] = ((int)(num11[k] - 48) + (int)(num12[k] - 48) + carry) % 10;//O(1)
                    if (((int)(num11[k] - 48) + (int)(num12[k] - 48) + carry) >= 10)//O(1)
                        carry = 1;//O(1)
                    else//O(1)
                        carry = 0;//O(1)
                }

                
                sum[max] = carry;//O(1)
                if (sum[max] == 0)//O(1)
                {
                    max = max - 1;//O(1)
                }
                
                StringBuilder sb = new StringBuilder();//O(1)



                for (int k = max; k >= 0; k--)//O(n)
                {
                    sb.Append(sum[k]);//O(1)

                }


                return sb.ToString();//O(1)
            }

            public string convertascii(string x)
            {
                int[] ascii = new int[x.Length];//O(1)
                string s = "";//O(1)
                for (int i = 0; i < x.Length; i++)//O(n)
                {
                    if (x[i] > 99)//O(1)
                    {
                        ascii[i] = (int)(x[i]);//O(1)
                        s = s + ascii[i];//O(1)
                    }
                    else//O(1)
                    {
                        //string s = ((int)(x[i])).ToString();
                        // s = "0" + s;
                        ascii[i] = (int)(x[i]);//O(1)
                        s = s + "0" + ascii[i];//O(1)
                    }
                }
                StringBuilder sb = new StringBuilder();//O(1)


                // if we have sign put it into the string 
                for (int k = 0; k < s.Length; k++)//O(n)
                {
                    sb.Append(s[k]);//O(1)

                }


                return sb.ToString();//O(1)




            }
            public string convertfromascii(string x)
            {
                string res = "";
                for (int i = 0; i < x.Length; i += 3)//O(n^2)
                {
                    string m = x.Substring(i, 3);//O(n)
                    int asc = int.Parse(m);//O(1)
                    char c = (char)(asc);//O(1)
                    res = res + c;//O(n)
                }

                return res;//O(1)
            }
    }
}
