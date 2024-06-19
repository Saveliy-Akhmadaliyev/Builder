using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Простое_расписние.Data;
using ADO.Net;
using Microsoft.Data.SqlClient;
using System.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using static System.Net.WebRequestMethods;
using Простое_расписние.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.NetworkInformation;

namespace parsing
{
    public class PostRequest
    {
        HttpWebRequest _request;
        string _address;

        public Dictionary<string, System.Object> Headers { get; set; }

        public string Response { get; set; }
        public string Accept { get; set; }
        public string Host { get; set; }
        public string Data { get; set; }
        public string ContentType { get; set; }
        public WebProxy Proxy { get; set; }
        public string Referer { get; set; }
        public string Useragent { get; set; }

        public PostRequest(string address)
        {
            _address = address;
            Headers = new Dictionary<string, System.Object>();
        }

        public void Run(CookieContainer cookieContainer)
        {
            _request = (HttpWebRequest)WebRequest.Create(_address);
            _request.Method = "Post";
            _request.CookieContainer = cookieContainer;
            _request.Proxy = Proxy;
            _request.Accept = Accept;
            _request.Host = Host;
            _request.ContentType = ContentType;
            _request.Referer = Referer;
            _request.UserAgent = Useragent;
            _request.Headers.Add("Authorization", "Bearer eyJ4NXQiOiJORGhpTkROalpHTmpORFl6WXpJMVpUQmhZakUxTUdOaE1EQTJOelk0TTJKa1pEQTVaREptTXciLCJraWQiOiJkMGVjNTE0YTMyYjZmODhjMGFiZDEyYTI4NDA2OTliZGQzZGViYTlkIiwiYWxnIjoiUlMyNTYifQ.eyJhdF9oYXNoIjoiZkR4d1BncmtKcm0tLVN1Vk5hN2dndyIsInN1YiI6ImJmZDVjNzBmLTQzNTUtNGQ1ZS05MDhiLWJjZTIzZDI1MzJlNyIsImF1ZCI6WyIzQ3VGM0ZzTnlSTGlGVmowSWwyZkl1amZ0dzBhIl0sImF6cCI6IjNDdUYzRnNOeVJMaUZWajBJbDJmSXVqZnR3MGEiLCJFeHRlcm5hbFBlcnNvbklkIjoiNGMyNzdiMTAtOGIwZS00ZDU5LTg4YWYtNWFkOTg5YzVmMmRhIiwiaXNzIjoiaHR0cHM6XC9cL3VyZnUtYXV0aC5tb2RldXMub3JnXC9vYXV0aDJcL3Rva2VuIiwicHJlZmVycmVkX3VzZXJuYW1lIjoi0JLQsNGF0YDQvtC80LXQtdCyINCS0LDRgdC40LvQuNC5INCQ0LvQtdC60YHQtdC10LLQuNGHIiwiZXhwIjoxNzE4Nzg2MTUyLCJub25jZSI6ImVFZC1WM1V0VFhGbE1qbG1RMEp6Y0RBdGF6Rk1jUzEzWjJRdVZ6ZFpiV3hFYTNFeWNXOUtaak53YzNaRCIsImlhdCI6MTcxODY5OTc1MiwicGVyc29uX2lkIjoiODc5YTRmNmMtNThiOC00ZGY4LTg0YjQtZGQ2Y2QzYWMxNGY3In0.jkm8Yr5mEowZ7fWYGIBrI855JgQNKWP1TvZh3TE29PcBzXChjlTphYyCceGFf-JnwlBLzE-U5Ft0RHvTynD0219idb3R_2M8WptttmnaOmndhJrvZ_ynEx-YctXjSqGx11WSBMTJXgSJgC8HgnS73ollNMyAbsLQZSEbBsSpcIGGgCNQ0U1uhdwvbL0D04O-ygjJTvvjPnRE4HVTyzK6hFaI4NzLG98fQh7R-5OZ3jEsvcZ62uo9v19DeRriPMD3o_4OGDudCLRKtQyY9q8zFZIm5B0H0-bDb8S3Ypx7d4kGl2IdEiqtbtnm9YB35RUUr7qRpMjD-3Slr7aEDli87Q\r\n");

            byte[] sentData = Encoding.UTF8.GetBytes(Data);
            _request.ContentLength = sentData.Length;
            Stream sendStream = _request.GetRequestStream();
            sendStream.Write(sentData, 0, sentData.Length);
            sendStream.Close();

            foreach (var pair in Headers)
            {
                _request.Headers.Add(pair.Key, (string)pair.Value);
            }

            try
            {
                HttpWebResponse response = (HttpWebResponse)_request.GetResponse();
                var stream = response.GetResponseStream();
                if (stream != null) Response = new StreamReader(stream).ReadToEnd();
            }
            catch (Exception)
            {
            }
        }
    }

    public class Lesson2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Vectors { get; set; }
        public string Info { get; set; }
    }

    public class Programm
    {
        static List<Lesson2> lesson2 = new List<Lesson2>();

        public static void Main(string[] args)
        {

            List<At> aTs0 = new List<At>();
            List<Lesson> lessons0 = new List<Lesson>();
            List<Teacher> teachers0 = new List<Teacher>();
            VectorParsing("Информатика и вычислительная техника, алгоритмы искуственного интеллекта", 1, aTs0, lessons0, teachers0, "{\"size\":500,\"timeMin\":\"2024-04-28T19:00:00Z\",\"timeMax\":\"2024-05-05T19:00:00Z\",\"specialtyCode\":[\"09.03.01\"],\"learningStartYear\":[2023],\"profileName\":[\"09.03.01/33.03 Алгоритмы искусственного интеллекта\"]}");

            List<At> aTs1 = new List<At>();
            List<Lesson> lessons1 = new List<Lesson>();
            List<Teacher> teachers1 = new List<Teacher>();
            VectorParsing("Информатика и вычислительная техника", 1, aTs1, lessons1, teachers1, "{\"size\":500,\"timeMin\":\"2024-04-28T19:00:00Z\",\"timeMax\":\"2024-05-05T19:00:00Z\",\"specialtyCode\":[\"09.03.01\"],\"learningStartYear\":[2023],\"profileName\":[\"09.03.01/33.01 Информатика и вычислительная техника\"]}");

            List<At> aTs2 = new List<At>();
            List<Lesson> lessons2 = new List<Lesson>();
            List<Teacher> teachers2 = new List<Teacher>();
            VectorParsing("Прикладная информатика", 1, aTs2, lessons2, teachers2, "{\"size\":500,\"timeMin\":\"2024-04-28T19:00:00Z\",\"timeMax\":\"2024-05-05T19:00:00Z\",\"specialtyCode\":[\"09.03.03\"],\"learningStartYear\":[2023]}");

            List<At> aTs3 = new List<At>();
            List<Lesson> lessons3 = new List<Lesson>();
            List<Teacher> teachers3 = new List<Teacher>();
            VectorParsing("Программная инженерия", 1, aTs3, lessons3, teachers3, "{\"size\":500,\"timeMin\":\"2024-04-28T19:00:00Z\",\"timeMax\":\"2024-05-05T19:00:00Z\",\"specialtyCode\":[\"09.03.04\"],\"learningStartYear\":[2023]}");

            List<At> aTs4 = new List<At>();
            List<Lesson> lessons4 = new List<Lesson>();
            List<Teacher> teachers4 = new List<Teacher>();
            VectorParsing("Информационная безопасность", 1, aTs4, lessons4, teachers4, "{\"size\":500,\"timeMin\":\"2024-04-28T19:00:00Z\",\"timeMax\":\"2024-05-05T19:00:00Z\",\"specialtyCode\":[\"10.03.01\"],\"learningStartYear\":[2023]}");

            List<At> aTs5 = new List<At>();
            List<Lesson> lessons5 = new List<Lesson>();
            List<Teacher> teachers5 = new List<Teacher>();
            VectorParsing("Электроника, радиотехника и системы связи", 1, aTs5, lessons5, teachers5, "{\"size\":500,\"timeMin\":\"2024-04-28T19:00:00Z\",\"timeMax\":\"2024-05-05T19:00:00Z\",\"specialtyCode\":[\"11.03.00\"],\"learningStartYear\":[2023]}");
            
            List<At> aTs6 = new List<At>();
            List<Lesson> lessons6 = new List<Lesson>();
            List<Teacher> teachers6 = new List<Teacher>();
            VectorParsing("Управление в технических системах", 1, aTs6, lessons6, teachers6, "{\"size\":500,\"timeMin\":\"2024-04-28T19:00:00Z\",\"timeMax\":\"2024-05-05T19:00:00Z\",\"specialtyCode\":[\"27.03.04\"],\"learningStartYear\":[2023]}");

            List<At> aTs7 = new List<At>();
            List<Lesson> lessons7 = new List<Lesson>();
            List<Teacher> teachers7 = new List<Teacher>();
            VectorParsing("Технология полиграфического и упаковочного производства", 1, aTs7, lessons7, teachers7, "{\"size\":500,\"timeMin\":\"2024-04-28T19:00:00Z\",\"timeMax\":\"2024-05-05T19:00:00Z\",\"specialtyCode\":[\"29.03.03\"],\"learningStartYear\":[2023]}");

            List<At> aTs8 = new List<At>();
            List<Lesson> lessons8 = new List<Lesson>();
            List<Teacher> teachers8 = new List<Teacher>();
            VectorParsing("Информатика и вычислительная техника", 2, aTs8, lessons8, teachers8, "{\"size\":500,\"timeMin\":\"2024-04-28T19:00:00Z\",\"timeMax\":\"2024-05-05T19:00:00Z\",\"specialtyCode\":[\"09.03.01\"],\"learningStartYear\":[2022],\"profileName\":[\"09.03.01/33.01 Информатика и вычислительная техника\"]}");

            List<At> aTs9 = new List<At>();
            List<Lesson> lessons9 = new List<Lesson>();
            List<Teacher> teachers9 = new List<Teacher>();
            VectorParsing("Прикладная информатика", 2, aTs9, lessons9, teachers9, "{\"size\":500,\"timeMin\":\"2024-04-28T19:00:00Z\",\"timeMax\":\"2024-05-05T19:00:00Z\",\"specialtyCode\":[\"09.03.03\"],\"learningStartYear\":[2022]}");

            List<At> aTs10 = new List<At>();
            List<Lesson> lessons10 = new List<Lesson>();
            List<Teacher> teachers10 = new List<Teacher>();
            VectorParsing("Программная инженерия", 2, aTs10, lessons10, teachers10, "{\"size\":500,\"timeMin\":\"2024-04-28T19:00:00Z\",\"timeMax\":\"2024-05-05T19:00:00Z\",\"specialtyCode\":[\"09.03.04\"],\"learningStartYear\":[2022]}");

            List<At> aTs11 = new List<At>();
            List<Lesson> lessons11 = new List<Lesson>();
            List<Teacher> teachers11 = new List<Teacher>();
            VectorParsing("Информационная безопасность", 2, aTs11, lessons11, teachers11, "{\"size\":500,\"timeMin\":\"2024-04-28T19:00:00Z\",\"timeMax\":\"2024-05-05T19:00:00Z\",\"specialtyCode\":[\"10.03.01\"],\"learningStartYear\":[2022]}");

            List<At> aTs13 = new List<At>();
            List<Lesson> lessons13 = new List<Lesson>();
            List<Teacher> teachers13 = new List<Teacher>();
            VectorParsing("Управление в технических системах", 2, aTs13, lessons13, teachers13, "{\"size\":500,\"timeMin\":\"2024-04-28T19:00:00Z\",\"timeMax\":\"2024-05-05T19:00:00Z\",\"specialtyCode\":[\"27.03.04\"],\"learningStartYear\":[2022]}");

            List<At> aTs14 = new List<At>();
            List<Lesson> lessons14 = new List<Lesson>();
            List<Teacher> teachers14 = new List<Teacher>();
            VectorParsing("Технология полиграфического и упаковочного производства", 2, aTs14, lessons14, teachers14, "{\"size\":500,\"timeMin\":\"2024-04-28T19:00:00Z\",\"timeMax\":\"2024-05-05T19:00:00Z\",\"specialtyCode\":[\"29.03.03\"],\"learningStartYear\":[2022]}");

            List<At> aTs15 = new List<At>();
            List<Lesson> lessons15 = new List<Lesson>();
            List<Teacher> teachers15 = new List<Teacher>();
            VectorParsing("Информатика и вычислительная техника", 3, aTs15, lessons15, teachers15, "{\"size\":500,\"timeMin\":\"2024-04-28T19:00:00Z\",\"timeMax\":\"2024-05-05T19:00:00Z\",\"specialtyCode\":[\"09.03.01\"],\"learningStartYear\":[2021],\"profileName\":[\"09.03.01/33.01 Информатика и вычислительная техника\"]}");

            List<At> aTs16 = new List<At>();
            List<Lesson> lessons16 = new List<Lesson>();
            List<Teacher> teachers16 = new List<Teacher>();
            VectorParsing("Прикладная информатика", 3, aTs16, lessons16, teachers16, "{\"size\":500,\"timeMin\":\"2024-04-28T19:00:00Z\",\"timeMax\":\"2024-05-05T19:00:00Z\",\"specialtyCode\":[\"09.03.03\"],\"learningStartYear\":[2021]}");

            List<At> aTs17 = new List<At>();
            List<Lesson> lessons17 = new List<Lesson>();
            List<Teacher> teachers17 = new List<Teacher>();
            VectorParsing("Программная инженерия", 3, aTs17, lessons17, teachers17, "{\"size\":500,\"timeMin\":\"2024-04-28T19:00:00Z\",\"timeMax\":\"2024-05-05T19:00:00Z\",\"specialtyCode\":[\"09.03.04\"],\"learningStartYear\":[2021]}");

            List<At> aTs22 = new List<At>();
            List<Lesson> lessons22 = new List<Lesson>();
            List<Teacher> teachers22 = new List<Teacher>();
            VectorParsing("Информатика и вычислительная техника", 4, aTs22, lessons22, teachers22, "{\"size\":500,\"timeMin\":\"2023-12-17T19:00:00Z\",\"timeMax\":\"2023-12-24T19:00:00Z\",\"specialtyCode\":[\"09.03.01\"],\"learningStartYear\":[2020],\"profileName\":[\"09.03.01/33.01 Информатика и вычислительная техника\"]}");

            List<At> aTs23 = new List<At>();
            List<Lesson> lessons23 = new List<Lesson>();
            List<Teacher> teachers23 = new List<Teacher>();
            VectorParsing("Прикладная информатика", 4, aTs23, lessons23, teachers23, "{\"size\":500,\"timeMin\":\"2023-12-17T19:00:00Z\",\"timeMax\":\"2023-12-24T19:00:00Z\",\"specialtyCode\":[\"09.03.03\"],\"learningStartYear\":[2020]}");

            List<At> aTs24 = new List<At>();
            List<Lesson> lessons24 = new List<Lesson>();
            List<Teacher> teachers24 = new List<Teacher>();
            VectorParsing("Программная инженерия", 4, aTs24, lessons24, teachers24, "{\"size\":500,\"timeMin\":\"2023-12-17T19:00:00Z\",\"timeMax\":\"2023-12-24T19:00:00Z\",\"specialtyCode\":[\"09.03.04\"],\"learningStartYear\":[2020]}");

            Output(aTs0);
            Output(aTs1);
            Output(aTs2);
            Output(aTs3);
            Output(aTs4);
            Output(aTs5);
            Output(aTs6);
            Output(aTs7);
            Output(aTs8);
            Output(aTs9);
            Output(aTs10);
            Output(aTs11);
            Output(aTs13);
            Output(aTs14);
            Output(aTs15);
            Output(aTs16);
            Output(aTs17);
            Output(aTs22);
            Output(aTs23);
            Output(aTs24);

            Output(lessons0);
            Output(lessons1);
            Output(lessons2);
            Output(lessons3);
            Output(lessons4);
            Output(lessons5);
            Output(lessons6);
            Output(lessons7);
            Output(lessons8);
            Output(lessons9);
            Output(lessons10);
            Output(lessons11);
            Output(lessons13);
            Output(lessons14);
            Output(lessons15);
            Output(lessons16);
            Output(lessons17);
            Output(lessons22);
            Output(lessons23);
            Output(lessons24);
            foreach (Lesson2 t in lesson2)
            {
                string s = $"INSERT INTO Lesson([Id], [Name], [Speciality], [Info]) VALUES({t.Id}, N'{t.Name}', N'{t.Vectors}', N'{t.Info}')";
                Console.WriteLine(s);
            }
            
            Output(teachers0);
            Output(teachers1);
            Output(teachers2);
            Output(teachers3);
            Output(teachers4);
            Output(teachers5);
            Output(teachers6);
            Output(teachers7);
            Output(teachers8);
            Output(teachers9);
            Output(teachers10);
            Output(teachers11);
            Output(teachers13);
            Output(teachers14);
            Output(teachers15);
            Output(teachers16);
            Output(teachers17);
            Output(teachers22);
            Output(teachers23);
            Output(teachers24);
        }

        static List<string> teachersName = new List<string>();

        private static void Output(List<At> aTs0)
        {
            foreach (var t in aTs0)
            {
                int isOnline = Convert.ToInt32(t.IsOnline);
                string s = $"INSERT INTO AT([Id], [Name], [Lesson], [Lector], [Mentor], [Number], [Place], [IsOnline]) VALUES({t.Id}, N'{t.Name}', N'{t.Lesson}', N'{t.Lector}', N'{t.Mentor}', {t.Number}, N'{t.Place}', {isOnline})";
                Console.WriteLine(s);
            }
        }

        static int i4 = 0;

        private static void Output(List<Lesson> lessons0)
        {
            foreach (var t in lessons0)
            {
                bool flag = true;
                foreach (var le in lesson2)
                {
                    if(le.Name == t.Name)
                    {
                        string cod = t.Speciality + "(" + t.Year + ")";
                        if (!le.Vectors.Contains(cod))
                        {
                            le.Vectors = le.Vectors + "." + t.Speciality + "(" + t.Year + ")";
                        }
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    var les = new Lesson2();
                    les.Id = i4;
                    les.Name = t.Name;
                    les.Vectors = t.Speciality + "(" + t.Year + ")";
                    lesson2.Add(les);
                    i4++;
                }
            }
        }

        private static void Output(List<Teacher> teachers0)
        {
            foreach (var t in teachers0)
            {
                string s = $"INSERT INTO Teacher([Id], [Name], [Info]) VALUES({t.Id}, N'{t.Name}', N'{t.Info}')";
                Console.WriteLine(s);
            }
        }

        private static void VectorParsing(string vector, int year, List<At> aTs, List<Lesson> lessons, List<Teacher> teachers, string data)
        {
            PostRequest postRequest = Parsing(data);
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(postRequest.Response);
            AtCreate(myDeserializedClass, aTs);
            LessonCreate(myDeserializedClass, lessons, vector, year);
            TeacherCreate(myDeserializedClass, teachers);
        }

        static int i3 = 0;
        private static void TeacherCreate(Root root, List<Teacher> teachers)
        {
            foreach (var per in root._embedded.persons)
            {
                var name = per.fullName;

                if (!teachersName.Contains(name))
                {
                    var teacher = new Teacher();
                    teacher.Name = name;
                    teacher.Info = "";
                    teacher.Id = i3;

                    i3++;

                    teachers.Add(teacher);
                    teachersName.Add(name);
                }
            }
        }

        static int i2 = 0;
        private static void LessonCreate(Root root, List<Lesson> lessons, string vector, int year)
        {
            var lessonNames = new List<string>();
            foreach (CycleRealization cyc in root._embedded.cyclerealizations)
            {
                var name = "";
                var nameLink = cyc._links.courseunitrealization.href.Substring(1);
                foreach (CourseUnitRealization2 cou in root._embedded.courseunitrealizations)
                {
                    if (nameLink == cou.id)
                    {
                        name = cou.name;
                    }
                }
                if (!lessonNames.Contains(name))
                {
                    var lesson = new Lesson();
                    lesson.Id = i2;
                    lesson.Name = name;
                    lesson.Year = year;
                    lesson.Speciality = vector;
                    lesson.Info = "";
                    lessonNames.Add(name);
                    lessons.Add(lesson);
                    i2++;
                }
            }
        }

        static int i = 0;
        private static void AtCreate(Root myDeserializedClass, List<At> aTs)
        {
            List<string> nameLinks = new List<string>();
            foreach (Event ev in myDeserializedClass._embedded.events)
            {
                At aT = new At();

                string name, lesson;
                NameAndLessonCreate(myDeserializedClass, out name, out lesson, ev);
                string lector, mentor;
                LectorAndMentorCreate(myDeserializedClass, ev, out lector, out mentor);
                int number = NumberCreate(ev);
                string place = PlaceCreate(myDeserializedClass, ev);
                bool isOnline = IsOnlineCreate(aT);

                aT.Id = i;
                aT.Name = name;
                aT.Lesson = lesson;
                aT.Lector = lector;
                aT.Mentor = mentor;
                aT.Number = number;
                aT.Place = place;
                aT.IsOnline = isOnline;
                aTs.Add(aT);
                i++;
            }
        }

        private static bool IsOnlineCreate(At aT)
        {
            var isOnline = false;
            if (aT.Place == "")
            {
                isOnline = true;
            }
            return isOnline;
        }

        private static string PlaceCreate(Root myDeserializedClass, Event ev)
        {
            var place = "";
            var roomLink = "";
            foreach (EventRoom room in myDeserializedClass._embedded.eventrooms)
            {
                if (room._links.@event.href.Substring(1) == ev.id)
                {
                    roomLink = room._links.room.href.Substring(1);
                }
            }
            foreach (Room2 room in myDeserializedClass._embedded.rooms)
            {
                if (room.id == roomLink)
                {
                    place = room.building.address + ", " + room.nameShort;
                }
            }

            return place;
        }

        private static int NumberCreate(Event ev)
        {
            int number;
            DateTime data;
            int hour;
            int dayOfWeek;
            int formatedHour = 0;
            data = ev.start;
            hour = data.Hour;
            dayOfWeek = (int)data.DayOfWeek;

            switch (hour)
            {
                case 6:
                    formatedHour = 1;
                    break;
                case 8:
                    formatedHour = 2;
                    break;
                case 10:
                    formatedHour = 3;
                    break;
                case 12:
                    formatedHour = 4;
                    break;
                case 14:
                    formatedHour = 5;
                    break;
                case 16:
                    formatedHour = 6;
                    break;
                case 17:
                    formatedHour = 7;
                    break;
                case 19:
                    formatedHour = 8;
                    break;
                case 20:
                    formatedHour = 9;
                    break;
            }

            number = 9 * (dayOfWeek - 1) + formatedHour;
            return number;
        }

        private static void LectorAndMentorCreate(Root myDeserializedClass, Event ev, out string lector, out string mentor)
        {
            lector = "";
            mentor = "";
            string lectorLink = "";
            string mentorLink = "";
            string organizer = ev.id;
            bool flag = true;
            foreach (EventAttendee evAt in myDeserializedClass._embedded.eventattendees)
            {
                if ((evAt._links.@event.href.Substring(1) == organizer) && flag)
                {
                    lectorLink = evAt._links.person.href.Substring(1);
                    flag = false;
                }
                else if (evAt._links.@event.href.Substring(1) == organizer)
                {
                    mentorLink = evAt._links.person.href.Substring(1);
                    break;
                }
            }
            foreach (Person2 per in myDeserializedClass._embedded.persons)
            {
                if (per.id == lectorLink)
                    lector = per.fullName;
                    mentor = lector;
                if (per.id == mentorLink)
                    mentor = per.fullName;
            }
        }

        private static void NameAndLessonCreate(Root myDeserializedClass, out string name, out string lesson, Event ev)
        {
            name = "";
            lesson = "";
            string track = "";
            string trackLink = "";
            var nameLink = ev._links.cyclerealization.href.Substring(1);
            foreach (CycleRealization cyc in myDeserializedClass._embedded.cyclerealizations)
            {
                if (cyc.id == nameLink)
                {
                    name = cyc.code;
                    lesson = cyc.courseUnitRealizationNameShort;
                    trackLink = cyc._links.courseunitrealization.href.Substring(1);
                    break;
                }
            }
            foreach (CourseUnitRealization2 cou  in myDeserializedClass._embedded.courseunitrealizations)
            {
                if (cou.id == trackLink)
                {
                    track = cou.name;
                }
            }
            name = name + ";" + track;
        }

        private static PostRequest Parsing(string data)
        {
            var proxy = new WebProxy("127.0.0.1:8888");
            var cookieContainer = new CookieContainer();
            var postRequest = new PostRequest("https://urfu.modeus.org/schedule-calendar-v2/api/calendar/events/search?tz=Asia/Yekaterinburg&authAction");
            postRequest.Data = data;
            postRequest.Accept = "application/json, text/plain, */*";
            postRequest.Useragent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/125.0.0.0 Safari/537.36";
            postRequest.ContentType = "application/json";
            postRequest.Referer = "https://urfu.modeus.org/schedule-calendar-v2/api/calendar/events/search?tz=Asia/Yekaterinburg&authAction";
            postRequest.Host = "urfu.modeus.org";
            postRequest.Proxy = proxy;
            postRequest.Headers.Add("Bx-ajax", "true");
            postRequest.Run(cookieContainer);
            return postRequest;
        }
    }

    public class At
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lesson { get; set; }
        public string Lector { get; set; }
        public string Mentor { get; set; }
        public int Number { get; set; }
        public string? Place { get; set; }
        public bool IsOnline { get; set; }
    }

    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }
        public int Year { get; set; }
        public string Info { get; set; }
    }

    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
    }

    public class Building
    {
        public string id { get; set; }
        public string name { get; set; }
        public string nameShort { get; set; }
        public string address { get; set; }
        public int displayOrder { get; set; }
        public string href { get; set; }
    }

    public class Building3
    {
        public string name { get; set; }
        public string nameShort { get; set; }
        public string address { get; set; }
        public string searchableAddress { get; set; }
        public int displayOrder { get; set; }
        public Links _links { get; set; }
        public string id { get; set; }
    }

    public class ControlObject
    {
        public string typeName { get; set; }
        public object typeShortName { get; set; }
        public string typeCode { get; set; }
        public string gradingScale { get; set; }
        public bool isRequired { get; set; }
        public Links _links { get; set; }
        public string id { get; set; }
    }

    public class CourseUnitRealization
    {
        public string href { get; set; }
    }

    public class CourseUnitRealization2
    {
        public string name { get; set; }
        public string nameShort { get; set; }
        public string prototypeId { get; set; }
        public object relevanceNumberDaysBeforeStart { get; set; }
        public Links _links { get; set; }
        public string id { get; set; }
    }

    public class CycleRealization2
    {
        public string href { get; set; }
    }

    public class CycleRealization
    {
        public string name { get; set; }
        public string nameShort { get; set; }
        public string code { get; set; }
        public string courseUnitRealizationNameShort { get; set; }
        public Links _links { get; set; }
        public string id { get; set; }
    }

    public class Duration
    {
        public string href { get; set; }
    }

    public class Duration2
    {
        public string eventId { get; set; }
        public int value { get; set; }
        public string timeUnitId { get; set; }
        public int minutes { get; set; }
        public Links _links { get; set; }
    }

    public class EducationalObject
    {
        public string typeCode { get; set; }
        public string externalObjectId { get; set; }
        public Links _links { get; set; }
        public string id { get; set; }
    }

    public class EducationalObject2
    {
        public string href { get; set; }
    }

    public class Embedded
    {
        public List<Event> events { get; set; }

        [JsonProperty("course-unit-realizations")]
        public List<CourseUnitRealization2> courseunitrealizations { get; set; }

        [JsonProperty("cycle-realizations")]
        public List<CycleRealization> cyclerealizations { get; set; }

        [JsonProperty("lesson-realization-teams")]
        public List<LessonRealizationTeam> lessonrealizationteams { get; set; }

        [JsonProperty("lesson-realizations")]
        public List<LessonRealization> lessonrealizations { get; set; }

        [JsonProperty("event-locations")]
        public List<EventLocation> eventlocations { get; set; }
        public List<Duration> durations { get; set; }

        [JsonProperty("event-rooms")]
        public List<EventRoom> eventrooms { get; set; }
        public List<Building> buildings { get; set; }

        [JsonProperty("event-teams")]
        public List<EventTeam> eventteams { get; set; }

        [JsonProperty("event-organizers")]
        public List<EventOrganizer> eventorganizers { get; set; }

        [JsonProperty("event-attendances")]
        public List<object> eventattendances { get; set; }

        [JsonProperty("person-results")]
        public List<object> personresults { get; set; }

        [JsonProperty("person-mid-check-results")]
        public List<object> personmidcheckresults { get; set; }

        [JsonProperty("educational-objects")]
        public List<EducationalObject> educationalobjects { get; set; }

        [JsonProperty("control-objects")]
        public List<ControlObject> controlobjects { get; set; }

        [JsonProperty("event-attendees")]
        public List<EventAttendee> eventattendees { get; set; }
        public List<Person2> persons { get; set; }

        [JsonProperty("rooms")]
        public List<Room2> rooms { get; set; }
    }

    public class Event
    {
        public string name { get; set; }
        public string nameShort { get; set; }
        public object description { get; set; }
        public string typeId { get; set; }
        public string formatId { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public DateTime startsAtLocal { get; set; }
        public DateTime endsAtLocal { get; set; }
        public DateTime startsAt { get; set; }
        public DateTime endsAt { get; set; }
        public HoldingStatus holdingStatus { get; set; }
        public object repeatedLessonRealization { get; set; }
        public List<string> userRoleIds { get; set; }
        public string lessonTemplateId { get; set; }
        public int __version { get; set; }
        public Links _links { get; set; }
        public string id { get; set; }
    }

    public class Event2
    {
        public string href { get; set; }
    }

    public class EventAttendee
    {
        public Links _links { get; set; }
        public string id { get; set; }
    }

    public class EventAttendeeRole
    {
        public string href { get; set; }
    }

    public class EventLocation
    {
        public string eventId { get; set; }
        public string customLocation { get; set; }
        public Links _links { get; set; }
    }

    public class EventOrganizer
    {
        public string eventId { get; set; }
        public Links _links { get; set; }
    }

    public class EventRoom
    {
        public Links _links { get; set; }
        public string id { get; set; }
        public string href { get; set; }
    }

    public class EventTeam
    {
        public string eventId { get; set; }
        public int size { get; set; }
        public Links _links { get; set; }
    }

    public class Format
    {
        public string href { get; set; }
    }

    public class GradingScale
    {
        public string href { get; set; }
    }

    public class Grid
    {
        public string href { get; set; }
    }

    public class HoldingStatus
    {
        public string id { get; set; }
        public string name { get; set; }
        public DateTime? audModifiedAt { get; set; }
        public string audModifiedBy { get; set; }
        public bool? audModifiedBySystem { get; set; }
    }

    public class HoldingStatusModifiedBy
    {
        public string href { get; set; }
    }

    public class LessonRealization
    {
        public string href { get; set; }
    }

    public class LessonRealization2
    {
        public string name { get; set; }
        public string nameShort { get; set; }
        public string prototypeId { get; set; }
        public int ordinal { get; set; }
        public Links _links { get; set; }
        public string id { get; set; }
    }

    public class LessonRealizationTeam
    {
        public string href { get; set; }
    }

    public class LessonRealizationTeam2
    {
        public string name { get; set; }
        public Links _links { get; set; }
        public string id { get; set; }
    }

    public class LessonRealizationTemplate
    {
        public string href { get; set; }
    }

    public class Links
    {
        public string href { get; set; }
        public Type type { get; set; }
        public Format format { get; set; }

        [JsonProperty("time-zone")]
        public TimeZone timezone { get; set; }
        public Grid grid { get; set; }

        [JsonProperty("course-unit-realization")]
        public CourseUnitRealization courseunitrealization { get; set; }

        [JsonProperty("cycle-realization")]
        public CycleRealization2 cyclerealization { get; set; }

        [JsonProperty("lesson-realization")]
        public LessonRealization lessonrealization { get; set; }

        [JsonProperty("lesson-realization-team")]
        public LessonRealizationTeam lessonrealizationteam { get; set; }

        [JsonProperty("lesson-realization-template")]
        public LessonRealizationTemplate lessonrealizationtemplate { get; set; }

        [JsonProperty("holding-status-modified-by")]
        public HoldingStatusModifiedBy holdingstatusmodifiedby { get; set; }
        public Location location { get; set; }
        public Duration duration { get; set; }
        public Team team { get; set; }
        public Organizers organizers { get; set; }
        public Event2 @event { get; set; }

        [JsonProperty("event-attendees")]
        public object eventattendees { get; set; }

        [JsonProperty("educational-object")]
        public EducationalObject educationalobject { get; set; }

        [JsonProperty("grading-scale")]
        public GradingScale gradingscale { get; set; }
        public Person person { get; set; }

        [JsonProperty("event-attendee-role")]
        public EventAttendeeRole eventattendeerole { get; set; }

        [JsonProperty("planning-period")]
        public PlanningPeriod planningperiod { get; set; }

        [JsonProperty("event-rooms")]
        public EventRoom eventrooms { get; set; }

        [JsonProperty("time-unit")]
        public TimeUnit timeunit { get; set; }
        public Room room { get; set; }
        public Building building { get; set; }
    }

    public class Location
    {
        public string href { get; set; }
    }

    public class Organizers
    {
        public string href { get; set; }
    }

    public class Page
    {
        public int size { get; set; }
        public int totalElements { get; set; }
        public int totalPages { get; set; }
        public int number { get; set; }
    }

    public class Person
    {
        public string href { get; set; }
    }

    public class Person2
    {
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string fullName { get; set; }
        public Links _links { get; set; }
        public string id { get; set; }
    }

    public class PlanningPeriod
    {
        public string href { get; set; }
    }

    public class Room
    {
        public string href { get; set; }
    }

    public class Room2
    {
        public string name { get; set; }
        public string nameShort { get; set; }
        public Building building { get; set; }
        public bool projectorAvailable { get; set; }
        public int totalCapacity { get; set; }
        public int workingCapacity { get; set; }
        public object deletedAtUtc { get; set; }
        public Links _links { get; set; }
        public string id { get; set; }
    }

    public class Root
    {
        public Embedded _embedded { get; set; }
        public Page page { get; set; }
    }

    public class Team
    {
        public string href { get; set; }
    }

    public class TimeUnit
    {
        public string href { get; set; }
    }

    public class TimeZone
    {
        public string href { get; set; }
    }

    public class Type
    {
        public string href { get; set; }
    }
}