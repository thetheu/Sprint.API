using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class PecasRepository : IPecaRepository
    {
        public List<Pecas> Listar()
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Pecas.Include(x => x.IdFornecedorNavigation).ToList();
            }
        }
       

        public Pecas BuscarPorId(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Pecas.FirstOrDefault(x => x.IdPeca == id);
            }
        }


        public void Cadastrar(Pecas peca)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                ctx.Pecas.Add(peca);
                ctx.SaveChanges();
            }
        }


        public void Deletar(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                Pecas pecas = ctx.Pecas.Find(id);
                ctx.Pecas.Remove(pecas);
                ctx.SaveChanges();
            }
        }


        public void Atualizar(Pecas peca)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                Pecas PecaBuscada = ctx.Pecas.FirstOrDefault(x => x.IdPeca == peca.IdPeca);
                PecaBuscada.Descricao = peca.Descricao;
                PecaBuscada.CodigoDaPeca = peca.CodigoDaPeca;
                PecaBuscada.IdFornecedor = peca.IdFornecedor;
                PecaBuscada.Peso = peca.Peso;
                PecaBuscada.PreçoDaVenda = peca.PreçoDaVenda;
                PecaBuscada.PreçoDoCusto = peca.PreçoDoCusto;
                ctx.Pecas.Update(PecaBuscada);
                ctx.SaveChanges();
            }
        }


        //public pecas listarporid(int id)
        //{
        //    using (autopecascontext ctx = new autopecascontext())
        //    {
        //        return ctx.pecas.include(x => x.idfornecedornavigation).include(x => x.idcargonavigation).firstordefault(x => x.idusuario == id);
        //    }
        //}
    }
}
