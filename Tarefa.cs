using System;

class Tarefa
{
    public string Responsavel { get; set; }
    public string Descricao { get; set; }
    public DateTime PrazoFinal { get; set; }
    public int IdProjeto { get; set; }

    public override string ToString()
    {
        return $"{Responsavel} - {Descricao} - Até dia: {PrazoFinal}.";
    }
}