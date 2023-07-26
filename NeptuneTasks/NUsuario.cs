using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using NeptuneTasks;

using System.Xml;


public class NUsuario
{
    private static List<Usuario> usuarios = new List<Usuario>();
    public static Usuario EntrarSistema(string nome, string senha)
    {
        foreach (Usuario obj in usuarios)
            if (obj.Nome == nome && obj.Senha == senha) return obj;
        return null;
    }
    public static List<Usuario> Listar()
    {
        return usuarios;
    }
    public static Usuario Listar(int id)
    {
        foreach (Usuario obj in usuarios)
            if (obj.Id == id) return obj;
        return null;
    }
    public static void Inserir(Usuario c)
    {
        int id = 0;
        foreach (Usuario obj in usuarios)
            if (obj.Id > id) id = obj.Id;
        id++;
        c.Id = id;
        usuarios.Add(c);
    }
    

    public static void Excluir(Usuario c)
    {
        Usuario obj = Listar(c.Id);
        if (obj != null) usuarios.Remove(obj);
    }
    public static void Salvar()
    {
        XmlSerializer xml = new XmlSerializer(typeof(List<Usuario>));
        using (StreamWriter writer = new StreamWriter("usuarios.xml"))
        {
            xml.Serialize(writer, usuarios);
        }
    }

    public static void Abrir()
    {
        XmlSerializer xml = new XmlSerializer(typeof(List<Usuario>));
        StreamReader reader = null;
        try
        {
            reader = new StreamReader("usuarios.xml");
            usuarios = (List<Usuario>)xml.Deserialize(reader);
        }
        catch
        { 
            usuarios = new List<Usuario>();
        }
        finally
        {
            if (reader != null) reader.Close();
        }
    }
    
    public static bool procuraNomeIgual(Usuario u)
    {
        foreach (Usuario obj in usuarios)
        {
            if(obj.Nome == u.Nome)
            {
                return true;
            }
        }
        return false;
    }
    public static bool procuraUsuarioParaEquipe(Usuario u)
    {
        foreach (Usuario obj in usuarios)
        {
            if (obj.Nome == u.Nome)
            {
                return true;
            }
        }
        return false;
    }
    public static bool procuraSeAdmin(Usuario u)
    {
        foreach (Usuario obj in usuarios)
        {
            if (obj.Admin == true)
            {
                return true;
            }
        }
        return false;
    }

}