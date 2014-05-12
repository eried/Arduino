using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryManager
{
    class LibraryUpdater
    {
        private readonly List<string> _filesToCheck;
        private List<LibraryProblem> _problems;

        public LibraryUpdater(List<string> filesToCheck)
        {
            _filesToCheck = filesToCheck;
            _problems = new List<LibraryProblem>();
        }

        public bool NeedsToBeFixed
        {
            get { return ChecksForIssues(false); }
        }

        private bool ChecksForIssues(bool writeChanges)
        {
            _problems = new List<LibraryProblem>();
            foreach (var f in _filesToCheck)
            {
            }
            return false;
        }

        public string GetVerboseProblems
        {
            get
            {
                return String.Join(Environment.NewLine, _problems.Select(p => " -" + p.Text).ToList());
            }
        }

        public bool FixLibraryFiles()
        {
            /*foreach (var f in fixTheseFiles)
                                {
                                    var temp = File.ReadAllText(f);
                                    File.WriteAllText(f, temp.Replace("\"WProgram.h\"", "\"Arduino.h\""));
                                }*/
            throw new NotImplementedException();
        }
    }

    internal struct LibraryProblem
    {
        public String Filename;
        public String Text;
    }
}
