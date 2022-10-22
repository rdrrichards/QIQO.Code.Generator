using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.IO;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace QIQO.Code.Generator
{
    [Generator]
    public class DataAccessLayerGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var outout = CreateMapClass().ToFullString(); //.ReplaceLineEndings("");
            context.AddSource("ProductMap.g.cs", outout);
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new MainSyntaxReceiver());
        }
        private CompilationUnitSyntax CreateMapClass()
        {
            return CompilationUnit()
                .WithUsings(
                    List<UsingDirectiveSyntax>(
                        new UsingDirectiveSyntax[]{
                            UsingDirective(
                                QualifiedName(
                                    QualifiedName(
                                        IdentifierName("QIQO"),
                                        IdentifierName("Business")),
                                    IdentifierName("Core"))),
                            UsingDirective(
                                IdentifierName("System")),
                            UsingDirective(
                                QualifiedName(
                                    QualifiedName(
                                        IdentifierName("System"),
                                        IdentifierName("Collections")),
                                    IdentifierName("Generic"))),
                            UsingDirective(
                                QualifiedName(
                                    IdentifierName("System"),
                                    IdentifierName("Data"))),
                            UsingDirective(
                                QualifiedName(
                                    QualifiedName(
                                        IdentifierName("System"),
                                        IdentifierName("Data")),
                                    IdentifierName("SqlClient")))}))
                .WithMembers(
                    SingletonList<MemberDeclarationSyntax>(
                        ClassDeclaration("ProductMap")
                        .WithModifiers(
                            TokenList(
                                Token(SyntaxKind.PublicKeyword)))
                        .WithBaseList(
                            BaseList(
                                SeparatedList<BaseTypeSyntax>(
                                    new SyntaxNodeOrToken[]{
                                        SimpleBaseType(
                                            IdentifierName("MapperBase")),
                                        Token(SyntaxKind.CommaToken),
                                        SimpleBaseType(
                                            IdentifierName("IProductMap"))})))))
                .NormalizeWhitespace();

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
