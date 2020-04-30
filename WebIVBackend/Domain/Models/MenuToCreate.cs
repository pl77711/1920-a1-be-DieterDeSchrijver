
﻿using System.Collections.Generic;

namespace WebIVBackend.Domain.Models
{
    public class MenuToCreate
    {
        public string Title { get; set; }

            public string Description { get; set; }
        
            public List<string> Allergies { get; set; }
            

            public MenuToCreate()
            {
            
            }

            public MenuToCreate(string title, string description)
            {
                Title = title;
                Description = description;
                Allergies = new List<string>();
            }
        
            public MenuToCreate(string title, string description, List<string> allergies)
            {
                Title = title;
                Description = description;
                Allergies = allergies;
            }

        
        
        
            
        
    }
}