using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.IO;

namespace QIQO.Code.Generator
{
	[Generator]
	public class DataAccessLayerGenerator : ISourceGenerator
	{
		public void Execute(GeneratorExecutionContext context)
		{
			var outout = @"public class ProductMapper {

}";
			context.AddSource("ProductMapper.g.cs", outout);
		}

		public void Initialize(GeneratorInitializationContext context)
		{
			context.RegisterForSyntaxNotifications(() => new MainSyntaxReceiver());
		}
	}

	public class MainSyntaxReceiver : ISyntaxReceiver
	{
		public int Index { get; set; }
		public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
		{
			if (syntaxNode is ClassDeclarationSyntax)
			{
				File.WriteAllText($@"C:\DEV\Source\RaD\QIQO.Code.Generator\QIQO.Code.Generator\{Index++}.txt", syntaxNode.GetText().ToString());
			}
		}
	}
}
