using BusStationIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusStationIS.Service
{
    public class HumanizHelper
    {

        public static string HumanizeContacts(IEnumerable<Contact> contacts)
        {
            string formattedContacts = string.Empty;
            foreach(var contact in contacts)
            {
                string contactType = HumanizeContactType(contact.Type);
                formattedContacts += contact.ContactContent + " (" + HumanizeContactType(contact.Type) + ") ";
                formattedContacts += ',';
            }
            formattedContacts = formattedContacts.TrimEnd(',');
            return formattedContacts;
        }

        private static string HumanizeContactType(ContactType type)
        {
            if(type == ContactType.EMail)
            {
                return "e-mail";
            }else if(type == ContactType.Facebook)
            {
                return "fb";
            }else if(type == ContactType.Fax)
            {
                return "fax";
            }else if(type == ContactType.Instagram)
            {
                return "insta";
            }else if(type == ContactType.LandlineTelephone)
            {
                return "fix phone";
            }else if(type == ContactType.MobilePhone)
            {
                return "mobile";
            }else
            {
                return "twitter";
            }
        }
    }
}
