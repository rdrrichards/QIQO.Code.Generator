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
                        NamespaceDeclaration(
                            QualifiedName(
                                QualifiedName(
                                    IdentifierName("QIQO"),
                                    IdentifierName("Data")),
                                IdentifierName("Access")))
                        .WithMembers(
                            SingletonList<MemberDeclarationSyntax>(
                                ClassDeclaration("ProductMap")
                                .WithModifiers(
                                    TokenList(
                                        new[]{
                                            Token(SyntaxKind.PublicKeyword),
                                            Token(SyntaxKind.PartialKeyword)}))
                                .WithBaseList(
                                    BaseList(
                                        SeparatedList<BaseTypeSyntax>(
                                            new SyntaxNodeOrToken[]{
                                                SimpleBaseType(
                                                    IdentifierName("MapperBase")),
                                                Token(SyntaxKind.CommaToken),
                                                SimpleBaseType(
                                                    IdentifierName("IProductMap"))})))
                                .WithMembers(
                                    List<MemberDeclarationSyntax>(
                                        new MemberDeclarationSyntax[]{
                                            MethodDeclaration(
                                                IdentifierName("Product"),
                                                Identifier("Map"))
                                            .WithModifiers(
                                                TokenList(
                                                    Token(SyntaxKind.PublicKeyword)))
                                            .WithParameterList(
                                                ParameterList(
                                                    SingletonSeparatedList<ParameterSyntax>(
                                                        Parameter(
                                                            Identifier("ds"))
                                                        .WithType(
                                                            IdentifierName("IDataReader")))))
                                            .WithBody(
                                                Block(
                                                    SingletonList<StatementSyntax>(
                                                        ThrowStatement(
                                                            ObjectCreationExpression(
                                                                IdentifierName("NotImplementedException"))
                                                            .WithArgumentList(
                                                                ArgumentList()))))),
                                            MethodDeclaration(
                                                GenericName(
                                                    Identifier("List"))
                                                .WithTypeArgumentList(
                                                    TypeArgumentList(
                                                        SingletonSeparatedList<TypeSyntax>(
                                                            IdentifierName("SqlParameter")))),
                                                Identifier("MapParamsForDelete"))
                                            .WithModifiers(
                                                TokenList(
                                                    Token(SyntaxKind.PublicKeyword)))
                                            .WithParameterList(
                                                ParameterList(
                                                    SingletonSeparatedList<ParameterSyntax>(
                                                        Parameter(
                                                            Identifier("entity"))
                                                        .WithType(
                                                            IdentifierName("Product")))))
                                            .WithBody(
                                                Block(
                                                    SingletonList<StatementSyntax>(
                                                        ThrowStatement(
                                                            ObjectCreationExpression(
                                                                IdentifierName("NotImplementedException"))
                                                            .WithArgumentList(
                                                                ArgumentList()))))),
                                            MethodDeclaration(
                                                GenericName(
                                                    Identifier("List"))
                                                .WithTypeArgumentList(
                                                    TypeArgumentList(
                                                        SingletonSeparatedList<TypeSyntax>(
                                                            IdentifierName("SqlParameter")))),
                                                Identifier("MapParamsForDelete"))
                                            .WithModifiers(
                                                TokenList(
                                                    Token(SyntaxKind.PublicKeyword)))
                                            .WithParameterList(
                                                ParameterList(
                                                    SingletonSeparatedList<ParameterSyntax>(
                                                        Parameter(
                                                            Identifier("entityKey"))
                                                        .WithType(
                                                            PredefinedType(
                                                                Token(SyntaxKind.IntKeyword))))))
                                            .WithBody(
                                                Block(
                                                    SingletonList<StatementSyntax>(
                                                        ThrowStatement(
                                                            ObjectCreationExpression(
                                                                IdentifierName("NotImplementedException"))
                                                            .WithArgumentList(
                                                                ArgumentList()))))),
                                            MethodDeclaration(
                                                GenericName(
                                                    Identifier("List"))
                                                .WithTypeArgumentList(
                                                    TypeArgumentList(
                                                        SingletonSeparatedList<TypeSyntax>(
                                                            IdentifierName("SqlParameter")))),
                                                Identifier("MapParamsForUpsert"))
                                            .WithModifiers(
                                                TokenList(
                                                    Token(SyntaxKind.PublicKeyword)))
                                            .WithParameterList(
                                                ParameterList(
                                                    SingletonSeparatedList<ParameterSyntax>(
                                                        Parameter(
                                                            Identifier("entity"))
                                                        .WithType(
                                                            IdentifierName("Product")))))
                                            .WithBody(
                                                Block(
                                                    SingletonList<StatementSyntax>(
                                                        ThrowStatement(
                                                            ObjectCreationExpression(
                                                                IdentifierName("NotImplementedException"))
                                                            .WithArgumentList(
                                                                ArgumentList())))))}))))))
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
