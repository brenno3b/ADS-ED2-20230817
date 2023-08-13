using ADS_ED2_20230817.Controllers;
using ADS_ED2_20230817.Models;

namespace ADS_ED2_20230817
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EscolaController escolaController = new();
            AlunoModel[] alunos = new AlunoModel[15];

            bool isFirstAccess = true;

            for (int i = 0; i < alunos.Length; i++) { alunos[i] = new AlunoModel(i + 1, $"Aluno {i + 1}"); }

            void handleAdicionarCurso()
            {
                Console.WriteLine("--- Adicionar curso ---");
                Console.WriteLine();

                Console.Write("Digite a descrição do curso: ");
                string descricao = Console.ReadLine();
                Console.WriteLine();

                CursoModel curso = new(descricao);

                bool isSuccess = escolaController.AdicionarCurso(curso);

                Console.WriteLine(isSuccess ? "Curso adicionado." : "Operação não permitida, limite de cursos atingido.");

                Console.WriteLine("\n--- Fim da adição de curso ---\n");
            }

            void handlePesquisarCurso()
            {
                Console.WriteLine("--- Consultar curso ---");
                Console.WriteLine();

                Console.Write("Digite o ID do curso: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                CursoModel curso = new(id);

                CursoModel foundCurso = escolaController.PesquisarCurso(curso);

                if (foundCurso.Id > -1)
                {
                    Console.WriteLine($"ID: {foundCurso.Id}");
                    Console.WriteLine($"Nome: {foundCurso.Descricao}");
                    Console.WriteLine($"Disciplinas: [");
                    for (int i = 0; i < foundCurso.Disciplinas.Length; i++) 
                    { 
                        Console.WriteLine($"  ID: {foundCurso.Disciplinas[i].Id}, descrição: {foundCurso.Disciplinas[i].Descricao}"); 
                    }
                    Console.WriteLine("]");
                }
                else
                {
                    Console.WriteLine("Curso não encontrado.");
                }

                Console.WriteLine("\n--- Fim da consulta de curso ---\n");
            }

            void handleRemoverCurso()
            {
                Console.WriteLine("--- Remover curso ---");
                Console.WriteLine();

                Console.Write("Digite o ID do curso: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                CursoModel curso = new(id);

                bool isSuccess = escolaController.RemoverCurso(curso);

                Console.WriteLine(isSuccess ? "Curso excluído." : "Exclusão não permitida, curso não encontrado ou há disciplinas associadas a este curso.");

                Console.WriteLine("\n--- Fim da exclusão de curso ---\n");
            }

            void handleAdicionarDisciplina()
            {
                Console.WriteLine("--- Adicionar disciplina ---");
                Console.WriteLine();

                Console.Write("Digite o ID do curso: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                CursoModel curso = new(id);

                CursoModel foundCurso = escolaController.PesquisarCurso(curso);

                if (foundCurso.Id > -1)
                {
                    Console.Write("Digite a descricao da disciplina: ");
                    string descricao = Console.ReadLine();
                    Console.WriteLine();

                    DisciplinaModel disciplina = new(descricao);

                    bool isSuccess = foundCurso.AdicionarDisciplina(disciplina);

                    Console.WriteLine(isSuccess ? "Disciplina adicionada." : "Adição não permitida, limite máximo de disciplina por curso atingido.");
                }
                else
                {
                    Console.WriteLine("Curso não encontrado");
                }

                Console.WriteLine("\n--- Fim da adição de disciplina ---\n");
            }

            void handlePesquisarDisciplina()
            {
                Console.WriteLine("--- Pesquisar disciplina ---");
                Console.WriteLine();

                Console.Write("Digite o ID do curso: ");
                int idCurso = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                CursoModel curso = new(idCurso);

                CursoModel foundCurso = escolaController.PesquisarCurso(curso);

                if (foundCurso.Id > -1)
                {
                    Console.Write("Digite o ID da disciplina: ");
                    int idDisciplina = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    DisciplinaModel disciplina = new(idDisciplina);

                    DisciplinaModel foundDisciplina = foundCurso.PesquisarDisciplina(disciplina);

                    if (foundDisciplina.Id > -1)
                    {
                        Console.WriteLine($"ID: {foundDisciplina.Id}");
                        Console.WriteLine($"Nome: {foundDisciplina.Descricao}");
                        Console.WriteLine($"Alunos: [");
                        for (int i = 0; i < foundDisciplina.Alunos.Length; i++)
                        {
                            Console.WriteLine($"  ID: {foundDisciplina.Alunos[i].Id}, nome: {foundDisciplina.Alunos[i].Nome}");
                        }
                        Console.WriteLine("]");
                    } 
                    else
                    {
                        Console.WriteLine("Disciplina não encontrada.");
                    }
                }
                else
                {
                    Console.WriteLine("Curso não encontrado.");
                }

                Console.WriteLine("\n--- Fim da pesquisa de disciplina ---\n");
            }

            void handleRemoverDisciplina()
            {
                Console.WriteLine("--- Remover disciplina ---");
                Console.WriteLine();

                Console.Write("Digite o ID do curso: ");
                int idCurso = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                CursoModel curso = new(idCurso);

                CursoModel foundCurso = escolaController.PesquisarCurso(curso);

                if (foundCurso.Id > -1)
                {
                    Console.Write("Digite o ID da disciplina: ");
                    int idDisciplina = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    DisciplinaModel disciplina = new(idDisciplina);

                    bool isSuccess = foundCurso.RemoverDisciplina(disciplina);

                    Console.WriteLine(isSuccess ? "Disciplina removida." : "Remoção não permitida, disciplina não existe ou há alunos matriculados.");
                }
                else
                {
                    Console.WriteLine("Curso não encontrado.");
                }

                Console.WriteLine("\n--- Fim da remoção de disciplina ---\n");
            }

            void handleMatricularAluno()
            {
                Console.WriteLine("--- Matricular aluno ---");
                Console.WriteLine();

                Console.Write("Digite o ID do curso: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                CursoModel curso = new(id);

                CursoModel foundCurso = escolaController.PesquisarCurso(curso);

                if (foundCurso.Id > -1)
                {
                    Console.Write("Digite o ID da disciplina: ");
                    int idDisciplina = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    DisciplinaModel disciplina = new(idDisciplina);

                    DisciplinaModel foundDisciplina = foundCurso.PesquisarDisciplina(disciplina);

                    if (foundDisciplina.Id > -1)
                    {
                        Console.Write("Digite o ID do aluno: ");
                        int idAluno = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();

                        AlunoModel aluno = alunos[idAluno];

                        bool isSuccess = foundDisciplina.MatricularAluno(aluno);

                        Console.WriteLine(isSuccess ? "Aluno matriculado." : "Matricular aluno não permitido, aluno já matriculado em um curso ou matriculado em 6 disciplinas");
                    }
                    else
                    {
                        Console.WriteLine("Disciplina não encontrada");
                    }
                }
                else
                {
                    Console.WriteLine("Curso não encontrado");
                }

                Console.WriteLine("\n--- Fim da matriculação do aluno ---\n");
            }

            void handleRemoverAluno()
            {
                Console.WriteLine("--- Remover aluno ---");
                Console.WriteLine();

                Console.Write("Digite o ID do curso: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                CursoModel curso = new(id);

                CursoModel foundCurso = escolaController.PesquisarCurso(curso);

                if (foundCurso.Id > -1)
                {
                    Console.Write("Digite o ID da disciplina: ");
                    int idDisciplina = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    DisciplinaModel disciplina = new(idDisciplina);

                    DisciplinaModel foundDisciplina = foundCurso.PesquisarDisciplina(disciplina);

                    if (foundDisciplina.Id > -1)
                    {
                        Console.Write("Digite o ID do aluno: ");
                        int idAluno = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();

                        AlunoModel aluno = alunos[idAluno];

                        bool isSuccess = foundDisciplina.DesmatricularAluno(aluno);

                        Console.WriteLine(isSuccess ? "Aluno desmatriculado." : "Aluno não matriculado nesta disciplina");
                    }
                    else
                    {
                        Console.WriteLine("Disciplina não encontrada");
                    }
                }
                else
                {
                    Console.WriteLine("Curso não encontrado");
                }

                Console.WriteLine("\n--- Fim da matriculação do aluno ---\n");
            }

            void handlePesquisarAluno()
            {
                Console.WriteLine("--- Pesquisar aluno ---");
                Console.WriteLine();

                Console.Write("Digite o nome do aluno: ");
                string nome = Console.ReadLine();
                Console.WriteLine();

                AlunoModel aluno = new AlunoModel();

                for (int i = 0; i < alunos.Length; i++)
                {
                    if (nome == alunos[i].Nome) { aluno = alunos[i]; break; }
                }

                if (aluno.Id > -1)
                {
                    Console.WriteLine($"O aluno {aluno.Nome} está matriculado nas seguintes disciplinas: [");
                    for(int i = 0; i < escolaController.Cursos.Length; i++)
                    {
                        for (int j = 0; j < escolaController.Cursos[i].Disciplinas.Length; j++)
                        {
                            for (int k = 0; k < escolaController.Cursos[i].Disciplinas[j].Alunos.Length; k++)
                            {
                                if (escolaController.Cursos[i].Disciplinas[j].Alunos[k].Id == aluno.Id)
                                {
                                    Console.WriteLine("  escolaController.Cursos[i].Disciplinas[j].Descricao");
                                }
                            }
                        }
                    }

                    Console.WriteLine("]");
                } 
                else
                {
                    Console.WriteLine("Aluno não encontrado");
                }

                Console.WriteLine("\n--- Fim da pesquisa do aluno ---\n");
            }

            void handleShowAllAlunos()
            {
                for (int i = 0; i < alunos.Length; i++)
                {
                    Console.WriteLine($"{alunos[i]} | index: {i}");
                }
                Console.WriteLine();
            }

            while (true)
            {
                if (isFirstAccess)
                {
                    Console.WriteLine("Os alunos foram criados via for loop com 15 espaços");
                    Console.WriteLine($"Exemplo: O primeiro aluno de um array é: {alunos[0]} e seu index no array é 0 e assim sucessivamente.");
                    Console.WriteLine();
                    isFirstAccess = false;
                }



                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar curso");
                Console.WriteLine("2. Pesquisar curso");
                Console.WriteLine("3. Remover curso");
                Console.WriteLine("4. Adicionar disciplina no curso");
                Console.WriteLine("5. Pesquisar disciplina");
                Console.WriteLine("6. Remover disciplina");
                Console.WriteLine("7. Matricular aluno na disciplina");
                Console.WriteLine("8. Remover aluno na disciplina");
                Console.WriteLine("9. Pesquisar aluno");
                Console.WriteLine("10. Mostrar todos alunos");

                Console.WriteLine();

                int option = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                if (option == 0) break;
                if (option == 1) handleAdicionarCurso();
                if (option == 2) handlePesquisarCurso();
                if (option == 3) handleRemoverCurso();
                if (option == 4) handleAdicionarDisciplina();
                if (option == 5) handlePesquisarDisciplina();
                if (option == 6) handleRemoverDisciplina();
                if (option == 7) handleMatricularAluno();
                if (option == 8) handleRemoverAluno();
                if (option == 9) handlePesquisarAluno();
                if (option == 10) handleShowAllAlunos();
            }

        }
    }
}