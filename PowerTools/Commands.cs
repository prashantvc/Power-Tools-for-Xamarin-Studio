using System;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;



namespace PowerTools
{
	public class FindMemebers : CommandHandler
	{
		protected async override void Run()
		{
			var document = IdeApp.Workbench?.ActiveDocument;

			if (IdeApp.Workbench?.ActiveDocument == null)
				return;

			var st = await document.AnalysisDocument.GetSyntaxTreeAsync();
			var root = st.GetRoot();

			var methods = root.DescendantNodes().OfType<MemberDeclarationSyntax>()
							  .Where(p => p.Kind() != SyntaxKind.NamespaceDeclaration);

			foreach (var method in methods)
			{
				Console.WriteLine(method.Kind());
			}
		}
	}
}