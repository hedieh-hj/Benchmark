using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using System.Linq;
using System.Text;

//this is console application with .net6
//instal benchmarkdotnet library 

namespace Benchmarker 
{
    class Program { 
        static void Main(string[] args)
        {
            var res = BenchmarkRunner.Run<Demo>();
        }
    }
    
    [MarkdownExporter, AsciiDocExporter, HtmlExporter, CsvExporter, RPlotExporter]
    [SimpleJob(RuntimeMoniker.Net472, baseline: true)] //use for check even .netframework 
    [MemoryDiagnoser] //how much memroy do you use
    public class Demo 
    {        
        [Benchmark(Baseline = true)]
        public string Get()
        {
            string output = "";

            for (int i = 0; i < 100; i++)
            {
                output += i; 
            }

            return output;
        }

        [Benchmark]
        public string Get2() {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < 100; i++)
            {
                output.Append(i);
            }

            return output.ToString();
        }
    }
}


