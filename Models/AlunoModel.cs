using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS_ED2_20230817.Models
{
    internal class AlunoModel
    {
        private readonly int _id;
        private readonly string _nome;

        public int Id { get { return _id; } }
        public string Nome { get { return _nome; } }

        public AlunoModel(int id, string nome)
        {
            _id = id;
            _nome = nome;
        }

        public AlunoModel(int id)
        {
            _id = id;
            _nome = "";
        }

        public AlunoModel(string nome)
        {
            _id = -1;
            _nome = nome;
        }

        public AlunoModel()
        {
            _id = -1;
            _nome = "";
        }

        public bool PodeMatricular(CursoModel[] cursos)
        {
            bool isFull = false;

            for (int i = 0; i < cursos.Length; i++)
            {
                int sum = 0;

                for (int j = 0; j < cursos[i].Disciplinas.Length; j++)
                {

                    for (int k = 0; k < cursos[i].Disciplinas[j].Alunos.Length; k++)
                    {
                        if (cursos[i].Disciplinas[j].Alunos[k].Id == _id) { sum++; }
                    }

                    if (sum >= 6) { isFull = true; break; }
                }

                if (sum > 0) { isFull = true; break; }
            }

            return !isFull;
        }

        public override string? ToString()
        {
            return "AlunoModel{" +
                "id: " + _id + ", " +
                "nome: " + _nome +
                "}";
        }
    }
}
