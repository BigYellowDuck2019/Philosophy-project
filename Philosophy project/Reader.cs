using System.IO;
using Philosophy_project.Model;

namespace Philosophy_project
{
	public static class Reader
	{
		public static Problem GetProblem(StreamReader reader)
		{
			Problem problem = new Problem(reader.ReadLine());
			string _string = reader.ReadLine();
			while (_string != "\n")
			{
				problem.OptionsList.Add(_string);
				_string = reader.ReadLine();
			}
			return problem;
		}
	}
}