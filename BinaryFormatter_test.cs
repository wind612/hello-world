﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Serialize
{
    [Serializable] //如果要想保存某个class中的字段,必须在class前面加个这样attribute(C#里面用中括号括起来的标志符)
    public class Person
    {
        public int age;

        public string name;

        [NonSerialized] //如果某个字段不想被保存,则加个这样的标志
        public string secret;

    }

    class BinaryFormatter_test
    {
        public static void test1()
        {

            Person person = new Person();

            person.age = 18;

            person.name = "tom";

            person.secret = "i will not tell you";

            FileStream stream = new FileStream(@".\person.dat", FileMode.Create);

            BinaryFormatter bFormat = new BinaryFormatter();

            bFormat.Serialize(stream, person);

            stream.Close();
        }

        public static void test2()
        {
            Person person = new Person();

            FileStream stream = new FileStream(@".\person.dat", FileMode.Open);

            BinaryFormatter bFormat = new BinaryFormatter();

            person = (Person)bFormat.Deserialize(stream);//反序列化得到的是一个object对象.必须做下类型转换

            stream.Close();

            Console.WriteLine(person.age + person.name + person.secret);//结果为18tom.因为secret没有有被序列化.
        }
    }
}
