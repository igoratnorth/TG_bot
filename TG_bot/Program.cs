using System;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Telegram.Bot;
using Telegram.Bot.Args;
using ServiceReference1;




namespace TG_bot
{
    class Program
    {
        public static ITelegramBotClient tg_client_test1;
        static void Main(string[] args)
        {
            tg_client_test1 = new TelegramBotClient("1999658156:AAHqszUUXtrxL3CayPYUS119rpUXPIZTwQs") { Timeout= TimeSpan.FromSeconds(10)};
            var inst1 = tg_client_test1.GetMeAsync().Result;
            Console.WriteLine($"id:{ inst1.Id} name:{inst1.Username}");
            tg_client_test1.OnMessage += Handler_OnMassage;
            tg_client_test1.StartReceiving();
            Console.ReadKey();
        }

        private static async void Handler_OnMassage(object sender, MessageEventArgs e)
        {
            var text = e?.Message;
            var text2 = e?.Message?.Text;

            Console.WriteLine($"e.masage '{text}' e.massage.text '{text2}' \n Info: '{e.Message.From}' ,  '{e.Message.Chat.Id}', '{e.Message.Contact}'");

            await tg_client_test1.SendTextMessageAsync(chatId:e.Message.Chat, text: $"Привет человек! что такое {e.Message.Text}");
        }
    }
    class TestClient

    {
        static void Main(string[] args)

        {

            OTWebService webSvc = new OTWebService();

            GetObjectListData gold = new GetObjectListData();



            // Replace the following lines with your code that

            // creates the request

            gold.folderPath = "ChangeMgmt\\RFCs";

            gold.recursive = true;

            gold.RequiredField = new RequiredField[5];

            gold.RequiredField[0] = new RequiredField();

            gold.RequiredField[0].Value = "Title";

            gold.RequiredField[1] = new RequiredField();

            gold.RequiredField[1].Value = "Attachments";

            gold.RequiredField[2] = new RequiredField();

            gold.RequiredField[2].Value = "Last Change";

            gold.RequiredField[3] = new RequiredField();

            gold.RequiredField[3].Value = "Priority";

            gold.RequiredField[4] = new RequiredField();

            gold.RequiredField[4].Value = "Answers";



            // Optional: use a filter

            Filter flt = new Filter();

            flt.name = "Open RFCs";

            gold.Item = flt;



            try

            {

                //simply call the proxy for the intended web method

                GetObjectListResult golr = webSvc.GetObjectList(gold);



                //Do something with the results

                if (golr.success)

                {

                    ObjectData[] myObjects = golr.Object;

                    for (int i = 0; i < myObjects.Length; i++)

                    {

                        foreach (object myItem in myObjects[i].Items)

                        {

                            if (myItem is NullVal)

                            {

                                string field = ((StringVal)myItem).name;

                                //do something...

                            }

                            else if (myItem is StringVal)

                            {

                                string field = ((StringVal)myItem).name;

                                string val = ((StringVal)myItem).Value;

                                //do something...

                            }

                            else if (myItem is DateTimeVal)

                            {

                                string field = ((DateTimeVal)myItem).name;

                                DateTime dt = ((DateTimeVal)myItem).Value;



                                //do something...

                            }

                            else if (myItem is LongIntVal)

                            {

                                string field = ((LongIntVal)myItem).name;

                                int val = ((LongIntVal)myItem).Value;



                                //do something...

                            }

                            else if (myItem is ShortIntVal)

                            {

                                //do something...

                            }

                            else if (myItem is TimeStampedMemoVal)

                            {

                                string field = ((TimeStampedMemoVal)myItem).name;

                                TimeStampedMemoSection[] sections = ((TimeStampedMemoVal)myItem).Section;



                                foreach (TimeStampedMemoSection sec in sections)

                                {

                                    DateTime dt = sec.date;

                                    string state = sec.state;

                                    string user = sec.user;

                                    string val = sec.Value;

                                    //do something...

                                }

                            }

                            else if (myItem is AttachmentsVal)

                            {

                                string field = ((AttachmentsVal)myItem).name;

                                Attachment[] att = ((AttachmentsVal)myItem).Attachments;



                                foreach (Attachment a in att)

                                {

                                    string name = a.name;

                                    DateTime dt = a.creationDate;

                                    bool bIsLink = a.link;

                                    byte[] val = a.Value;

                                    string descr = a.description;

                                    DateTime mod = a.lastModification;

                                    //do something...

                                }

                            }

                            else if (myItem is ReferenceListVal)

                            {

                                string field = ((ReferenceListVal)myItem).name;

                                int[] objects = ((ReferenceListVal)myItem).objectIds;

                                //do something...

                            }

                        }

                    }

                }

                else

                {

                    string err = golr.errorMsg;

                }

            }

            catch (Exception ex)

            {

                string err = ex.Message;

            }

        }


    }


}
