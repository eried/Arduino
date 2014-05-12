using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;

namespace BoardsEditor
{
    class BoardsContainer
    {
        public BoardsContainer(string inputFile)
        {
            Boards = Parse(inputFile);
        }

        public List<Board> Boards { get; set; }

        private static List<Board> Parse(string inputFile)
        {
            var s = new Dictionary<String, List<Property>>();

            foreach (var l in File.ReadAllLines(inputFile))
            {
                if (!l.StartsWith("#") && l.Contains('=') && l.Contains('.'))
                {
                    var parts = l.Split(new[] {'='}, 2);
                    var name = parts[0].Split(new[] {'.'}, 2);

                    if (!s.ContainsKey(name[0]))
                        s.Add(name[0], new List<Property>());

                    s[name[0]].Add(new Property() {Name = name[1], Value = parts[1]});
                }
            }

            return s.Select(def => new Board() {Token = def.Key, Properties = def.Value}).ToList();
        }

        public string[] GetPropertiesValues(string name)
        {
            var s = new List<String>();
            
            foreach (var b in Boards)
            {
                foreach (var p in b.Properties.Where(p => p.Name == name))
                {
                    if(!s.Contains(p.Value))
                        s.Add(p.Value);
                    break;
                }
            }

            s.Sort();
            return s.ToArray();
        }
    }

    internal struct Property
    {
        public String Name;
        public String Value;
    }

    class Board 
    {
        public List<Property> Properties;

        public String Name
        {
            get 
            {
                if (_name == null)
                {
                    _name = Token;
                    foreach (var p in Properties)
                    {
                        if (p.Name.Equals("name", StringComparison.OrdinalIgnoreCase))
                        {
                            _name = p.Value;
                            break;
                        }
                    }
                }

                return _name;
            }
        }

        public String Token;
        public Boolean Enabled = true;
        private string _name = null;
    }
}
