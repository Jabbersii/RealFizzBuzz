using RealFizzBuzz.Pipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealFizzBuzz
{
    public class Runner
    {
        private readonly IEnumerable<int> source;
        private readonly IList<IPipe> pipes;
        private readonly IDictionary<string, int> report = new Dictionary<string, int>();

        public Runner(IEnumerable<int> source, IList<IPipe> pipes)
        {
            if (pipes.Count == 0)
            {
                throw new ArgumentException("Must supply at least 1 pipe", nameof(pipes));
            }

            this.source = source;
            this.pipes = pipes;
            report.Add("integer", 0);
        }

        public IDictionary<string, int> Report => report;

        public IEnumerable<string> Run()
        {
            foreach (var item in source)
            {
                var pipe = pipes.First(p => p.Check(item));
                string result = pipe.Process(item);
                ReportResult(result);

                yield return result;
            }
        }

        private void ReportResult(string print)
        {
            if (int.TryParse(print, out int a))
            {
                report["integer"] += 1;
            }
            else
            {
                if (report.ContainsKey(print))
                {
                    report[print] += 1;
                }
                else
                {
                    report.Add(print, 1);
                }
            }
        }
    }
}
