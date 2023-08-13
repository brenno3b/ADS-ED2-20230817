using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS_ED2_20230817.Models
{
    internal class CursoModel
    {
        private readonly int _id;
        private readonly string _descricao;
        private DisciplinaModel[] _disciplinas;
        private int _quantity
        {
            get
            {
                int sum = 0;

                while (sum < _disciplinas.Length && _disciplinas[sum].Id != -1) { sum++; }

                return sum;
            }
        }

        public int Id { get { return _id; } }
        public string Descricao { get { return _descricao; } }
        public DisciplinaModel[] Disciplinas { get { return _disciplinas; } }

        public CursoModel(int id, string descricao)
        {
            _id = id;
            _descricao = descricao;
            _disciplinas = new DisciplinaModel[12];

            for(int i = 0; i < _disciplinas.Length; i++)
            {
                _disciplinas[i] = new DisciplinaModel();
            }
        }

        public CursoModel(int id)
        {
            _id = id;
            _descricao = "";
            _disciplinas = new DisciplinaModel[12];

            for (int i = 0; i < _disciplinas.Length; i++)
            {
                _disciplinas[i] = new DisciplinaModel();
            }
        }

        public CursoModel(string descricao)
        {
            _id = -1;
            _descricao = descricao;
            _disciplinas = new DisciplinaModel[12];

            for (int i = 0; i < _disciplinas.Length; i++)
            {
                _disciplinas[i] = new DisciplinaModel();
            }
        }

        public CursoModel()
        {
            _id = -1;
            _descricao = "";
            _disciplinas = new DisciplinaModel[12];

            for (int i = 0; i < _disciplinas.Length; i++)
            {
                _disciplinas[i] = new DisciplinaModel();
            }
        }

        public bool AdicionarDisciplina(DisciplinaModel disciplina)
        {
            if (_quantity < _disciplinas.Length)
            {
                int index = 0;

                while (index < _disciplinas.Length && _disciplinas[index].Id != -1) { index++; }

                if (index < _disciplinas.Length)
                {
                    _disciplinas[index] = new DisciplinaModel(index + 1, disciplina.Descricao);
                    return true;
                }
            }

            return false;
        }

        public DisciplinaModel PesquisarDisciplina(DisciplinaModel disciplina)
        {
            int index = IndexOf(disciplina);

            if (index > -1) { return _disciplinas[index]; }

            return new DisciplinaModel();
        }

        public bool RemoverDisciplina(DisciplinaModel disciplina)
        {
            int index = IndexOf(disciplina);

            if (index > -1)
            {
                bool isEmpty = true;

                for (int i = 0; i < disciplina.Alunos.Length; i++)
                {
                    if (disciplina.Alunos[i].Id != -1) { isEmpty = false; break; }
                }

                if (isEmpty) { _disciplinas[index] = new DisciplinaModel(); return true; }
            }
            return false;
        }

        private int IndexOf(DisciplinaModel disciplina)
        {
            int i = 0;

            while (i < _disciplinas.Length && _disciplinas[i].Id != disciplina.Id) { i++; }

            if (i < _disciplinas.Length) { return i; }

            return -1;
        }

        public override string? ToString()
        {
            string str = "";

            for (int i = 0; i < _disciplinas.Length; i++) { str += _disciplinas[i].ToString(); }

            return "CursoModel{" +
                "id: " + _id + ", " +
                "descricao: " + _descricao + ", " +
                "disciplinas: " + str +
                "}";
        }
    }
}
