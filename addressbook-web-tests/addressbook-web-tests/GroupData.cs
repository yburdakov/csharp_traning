﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class GroupData
    {
        private string name;
        private string header = "";
        private string footer = "";

        public GroupData(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Header
        {
            get
            {
                return Header;
            }
            set
            {
                header = value;
            }
        }
        public string Footer
        {
            get
            {
                return Footer;
            }
            set
            {
                footer = value;
            }
        }
    }
}
