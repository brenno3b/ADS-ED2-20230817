using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS_ED2_20230817.Models
{
    internal class DisciplinaModel
    {
        private readonly int _id;
        private readonly string _descricao;
        private AlunoModel[] _alunos;
        private int _quantity
        {
            get
            {
                int sum = 0;

                while (sum < _alunos.Length && _alunos[sum].Id != -1) { sum++; }

                return sum;
            }
        }

        public int Id { get { return _id; } }
        public string Descricao { get { return _descricao; } }
        public AlunoModel[] Alunos { get { return _alunos; } }

        public DisciplinaModel(int id, string descricao)
        {
            _id = id;
            _descricao = descricao;
            _alunos = new AlunoModel[15];

            for(int i = 0; i < _alunos.Length; i++)
            {
                _alunos[i] = new AlunoModel();
            }
        }

        public DisciplinaModel(int id)
        {
            _id = id;
            _descricao = "";
            _alunos = new AlunoModel[15];

            for (int i = 0; i < _alunos.Length; i++)
            {
                _alunos[i] = new AlunoModel();
            }
        }

        public DisciplinaModel(string descricao)
        {
            _id = -1;
            _descricao = descricao;
            _alunos = new AlunoModel[15];

            for (int i = 0; i < _alunos.Length; i++)
            {
                _alunos[i] = new AlunoModel();
            }
        }

        public DisciplinaModel()
        {
            _id = -1;
            _descricao = "";
            _alunos = new AlunoModel[15];

            for (int i = 0; i < _alunos.Length; i++)
            {
                _alunos[i] = new AlunoModel();
            }
        }

        public bool MatricularAluno(AlunoModel aluno)
        {
            if (_quantity < _alunos.Length)
            {
                int index = 0;

                while (index < _alunos.Length && _alunos[index].Id != -1) { index++; }

                if (index < _alunos.Length)
                {
                    _alunos[index] = new AlunoModel(index + 1, aluno.Nome);
                    return true;
                }
            }

            return false;
        }

        public bool DesmatricularAluno(AlunoModel aluno) 
        {
            int index = IndexOf(aluno);

            if (index > -1) { _alunos[index] = new AlunoModel(); return true; }

            return false;
        }

        private int IndexOf(AlunoModel aluno)
        {
            int i = 0;

            while (i < _alunos.Length && _alunos[i].Id != aluno.Id) { i++; }

            if (i < _alunos.Length) { return i; }

            return -1;
        }

        public override string? ToString()
        {
            return "DisciplinaModel{" +
                "id: " + _id + ", " +
                "descricao: " + _descricao + ", " +
                "alunos: " + _alunos.ToString() + 
                "}";
        }
    }
}
