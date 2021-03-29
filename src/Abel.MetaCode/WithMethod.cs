﻿using System;
using System.Linq;
using System.Reflection;
using Abel.MetaCode.Interfaces;

namespace Abel.MetaCode
{
	public class WithMethod : With, IWithMethod
	{
		private string _parameters = string.Empty;
		private string _returnTypeName = "void";

		public WithMethod(string name, ICodeGen codeGen)
			: base(name, codeGen)
		{
		}

		public IWithMethod WithReturnType(string returnTypeName)
		{
			_returnTypeName = returnTypeName;
			return this;
		}

		public IWithMethod WithParameters(string parameters)
		{
			_parameters = parameters;
			return this;
		}

		public IWithMethod WithParameters(ParameterInfo[] parameters) =>
			WithParameters(string.Join(", ", parameters.Select(p => $"{p.ParameterType.Name} {p.Name}")));

		public override ICodeGen WithContent(Action<ICodeGen> action) =>
			CodeGen.AddScoped($"{Modifiers} {_returnTypeName} {Name}({_parameters})", action);
	}
}
