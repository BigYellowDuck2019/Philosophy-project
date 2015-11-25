using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Mita.Mvvm;
using Philosophy_project.Annotations;
using Philosophy_project.Model;

//using Microsoft.Expression.Interactivity.Core;

namespace Philosophy_project
{
	public class ViewModel: INotifyPropertyChanged
	{
		public ViewModel()
		{
			Problems = new List<Problem>();
			//var inputFile = new StreamReader(@"C:\Users\p_p\Desktop\problems.txt");
			//while (!inputFile.EndOfStream)
			//{
			//	Problems.Add(Reader.GetProblem(inputFile));
			//}
			//CurrentProblem = Problems[0];
			CurrentProblemNumber = 0;
			ConfirmCommand = new DelegateCommand(Confirm); //, () =>  CurrentProblem.SelectedOption !=0);
		}


		private void Confirm()
		{
			byte selectedAnswer = 0;
			for (byte i = 0; i < _optionsBools.Length; i++)
			{
				if (!_optionsBools[i]) continue;
				selectedAnswer = i;
				break;
			}
			CurrentProblem.SelectedOption = selectedAnswer;
			NextQuestion();
		}

		private void NextQuestion()
		{
			CurrentProblemNumber++;
		}

		public List<Problem> Problems { get; set; }

		private Problem CurrentProblem => Problems[CurrentProblemNumber];
		public string CurrentQuestionHeader =>
			$"Вопрос № {CurrentProblemNumber} из {Problems.Count}: {CurrentProblem.Question}";

		public byte CurrentProblemNumber { get; set; }

		public bool IsAnswerSelected => _optionsBools[0] || _optionsBools[1] || _optionsBools[2] || _optionsBools[3];

		public string FirstOption => CurrentProblem.OptionsList[0];
		public string SecondOption => CurrentProblem.OptionsList[1];
		public string ThirdOption => CurrentProblem.OptionsList[2];
		public string FourthOption => CurrentProblem.OptionsList[3];

		public ICommand ConfirmCommand{ get; set; }

		private readonly bool[] _optionsBools = new bool[4];

		public bool FirstOptionBool
		{
			get { return _optionsBools[0]; }
			set
			{
				_optionsBools[0] = value;
				OnPropertyChanged(nameof(IsAnswerSelected));
			}
		}
		public bool SecondOptionBool
		{
			get { return _optionsBools[1]; }
			set
			{
				_optionsBools[1] = value;
				OnPropertyChanged(nameof(IsAnswerSelected));

			}
		}
		public bool ThirdOptionBool
		{
			get { return _optionsBools[2]; }
			set
			{
				_optionsBools[2] = value;
				OnPropertyChanged(nameof(IsAnswerSelected));

			}
		}
		public bool FourthOptionBool
		{
			get { return _optionsBools[3]; }
			set
			{
				_optionsBools[3] = value;
				OnPropertyChanged(nameof(IsAnswerSelected));

			}
		}
		public void Initialize()
		{
			string filePath = @"Problems.txt";
			if (!File.Exists(filePath))
			{
				//File.Create(filePath);
				File.WriteAllText(filePath, @"K какой школе вы относитесь?
Phy Пифагор
Plu Платон
Arx Архимед
Школа№11

Это правда ?
Надо посчитать
Это как посмотреть
Точно же!
Лолшто
");
			}
			var inputFile = new StreamReader(filePath);
			while (!inputFile.EndOfStream)
			{
				Problems.Add(Reader.GetProblem(inputFile));
			}
			inputFile.Close();
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}