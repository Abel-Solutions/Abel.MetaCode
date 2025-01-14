﻿using System;

namespace Abel.CodeGeneration.Interfaces
{
	public interface IWithConstructor
	{
		IWithConstructor WithModifier(string modifier);

		IWithConstructor WithModifiers(params string[] modifiers);

		IWithConstructor WithParameter(string parameter);

		IWithConstructor WithParameters(params string[] parameters);

		IClassGenerator WithContent(Action<IMethodGenerator> action);
	}
}