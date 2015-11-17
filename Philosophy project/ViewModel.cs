using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using Philosophy_project.Model;

namespace Philosophy_project
{
	public class ViewModel
	{
		public List<Problem> Problems { get; set; }

		private Problem CurrentProblem => Problems[CurrentProblem.Number];
		public string CurrentQuestionHeader =>
			$"Вопрос № {CurrentProblem.Number} из {Problems.Count}: {CurrentProblem.Question}";

		public string FirstOption => CurrentProblem.OptionsList[0];
		public string SecondOption => CurrentProblem.OptionsList[1];
		public string ThirdOption => CurrentProblem.OptionsList[2];
		public string FourthOption => CurrentProblem.OptionsList[3];

		private readonly bool[] _optionsBools = new bool[4];

		public bool FirstOptionBool
		{
			get { return _optionsBools[0]; }
			set { _optionsBools[0] = value; }
		}
		public bool SecondOptionBool
		{
			get { return _optionsBools[1]; }
			set { _optionsBools[1] = value; }
		}
		public bool ThirdOptionBool
		{
			get { return _optionsBools[2]; }
			set { _optionsBools[2] = value; }
		}
		public bool FourthOptionBool
		{
			get { return _optionsBools[3]; }
			set { _optionsBools[3] = value; }
		}

		//public ICommand ChooseFirstOptionCommand { get; set; }
		//public ICommand ChooseSecondOptionCommand { get; set; }
		//public ICommand ChooseThirdOptionCommand { get; set; }
		//public ICommand ChooseFourthOptionCommand { get; set; }

		//public void ChooseOptionForCurrentProblem(byte optionNumber)
		//{
		//	CurrentProblem.SelectedOption = optionNumber;
		//}
		public void Initialize()
		{
			if (!File.Exists(@"problems.txt"))
			{
				File.Create(@"problems.txt");
				File.WriteAllText(@"problems.txt", "");
			}
			var inputFile = new StreamReader(@"problems.txt");
			while (!inputFile.EndOfStream)
			{
				Problems.Add(Reader.GetProblem(inputFile));
			}
			inputFile.Close();
		}
	}
}