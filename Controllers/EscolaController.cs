using ADS_ED2_20230817.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ADS_ED2_20230817.Controllers
{
    internal class EscolaController
    {
        private CursoModel[] _cursos;
        private int _quantity
        {
            get
            {
                int sum = 0;

                while (sum < _cursos.Length && _cursos[sum].Id != -1) { sum++; }

                return sum;
            }
        }

        public CursoModel[] Cursos { get { return _cursos; } }

        public EscolaController()
        {
            _cursos = new CursoModel[5];

            for(int i = 0; i < _cursos.Length; i++)
            {
                _cursos[i] = new CursoModel();
            }
        }

        public bool AdicionarCurso(CursoModel curso)
        {
            if (_quantity < _cursos.Length)
            {
                int index = 0;

                while (index < _cursos.Length && _cursos[index].Id != -1) { index++; }

                if (index < _cursos.Length)
                {
                    _cursos[index] = new CursoModel(index + 1, curso.Descricao);
                    return true;
                }
            }

            return false;
        }

        public CursoModel PesquisarCurso(CursoModel curso)
        {
            int index = IndexOf(curso);

            if (index > -1) { return _cursos[index]; }

            return new CursoModel();
        }

        public bool RemoverCurso(CursoModel curso)
        {
            int index = IndexOf(curso);

            if (index > -1)
            {
                bool isEmpty = true;

                for (int i = 0; i < curso.Disciplinas.Length; i++)
                {
                    if (curso.Disciplinas[i].Id != -1) { isEmpty = false; break; }
                }

                if (isEmpty) { _cursos[index] = new CursoModel(); return true; }
            }
            return false;
        }

        private int IndexOf(CursoModel curso)
        {
            int i = 0;

            while (i < _cursos.Length && _cursos[i].Id != curso.Id) { i++; }

            if (i < _cursos.Length) { return i; }

            return -1;
        }

        public override string? ToString()
        {
            return "EscolaModel{" +
                "cursos: " + _cursos.ToString() +
                "}";
        }
    }
}
