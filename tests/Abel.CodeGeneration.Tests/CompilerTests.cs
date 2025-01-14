﻿using System;
using System.IO;
using System.Text;
using Abel.CodeGeneration.Extensions;
using Abel.CodeGeneration.Generators;
using Abel.CodeGeneration.Interfaces;
using FluentAssertions;
using Microsoft.CodeAnalysis;
using Xunit;

namespace Abel.CodeGeneration.Tests
{
	public class CompilerTests
	{
		private readonly ICodeGenerator _codeGenerator = new CodeGenerator();
		private readonly ICompiler _compiler = new Compiler();

		[Fact]
		public void Compiler_Code_CodeIsRunCorrectly()
		{
			var code = _codeGenerator
				.Using("System")
				.AddNamespace("MetaCode", nspace => nspace
					.AddClass("Lol", @class => @class
						.AddMethod("Main")
						.WithModifiers("public static")
						.WithContent(method => method
							.AddLine("Console.Write(\"foo\");"))))
				.Generate();

			var sb = new StringBuilder();
			Console.SetOut(new StringWriter(sb));

			_compiler
				.Compile(code, OutputKind.ConsoleApplication)
				.Execute();

			sb.ToString().Should().Be("foo");
		}
	}
}
