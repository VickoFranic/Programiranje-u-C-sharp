using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Labs
{
    class FormInfo
    {
        public int width;
        public int height;
        public int xPos;
        public int yPos;

        public FormInfo(int w, int h, int x, int y)
        {
            width = w;
            height = h;
            xPos = x;
            yPos = y;
        }

        /**
         * Serialize data to JSON string and write to file
         * using JSON.net package
         */
        public void serialize()
        {
            string output = JsonConvert.SerializeObject(this);
            File.WriteAllText(@"./files/formInfo.json", output);
        }
    }
}
