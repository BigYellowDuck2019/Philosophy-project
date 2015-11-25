using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Philosophy_project.Model
{
	public class Problem
	{
		public Problem(string question)
		{
			Question = question;
			OptionsList = new List<string>();
		}

		private byte _selectedOption;
		public string Question { get; set; }

		public List<string> OptionsList { get; set; }

		//public byte Number { get; set; }

		public byte SelectedOption
		{
			get { return _selectedOption; }
			set {
				if (value < 1 || value > OptionsList.Count)
				{
					throw new InvalidOperationException("govno");
				}
				_selectedOption = value; }
		}
	}
}