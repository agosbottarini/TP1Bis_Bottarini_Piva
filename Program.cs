using System.Collections.Generic;

Dictionary<char, int> dicRecaudacion = new Dictionary<char, int>();
string respuestaUser;


respuestaUser = ValidarRespuesta();
while(respuestaUser!="FIN")
{
    if(respuestaUser == "ESTADISTICAS")
    {
        Estadisticas();
    }
    else
    {
        Recaudacion();
    }
    respuestaUser = IngresarTexto("Desea ver estadisticas/recaudar? [ESTADISTICAS/RECAUDAR/FIN]");
}


void Recaudacion()
{
    char curso = IngresarChar("Ingrese el curso a recaudar:");

    while(dicRecaudacion.Keys.Contains(curso))
    {
        curso = IngresarChar("El curso ya fue ingresado, ingrese otro curso a recaudar:");
    }
    int alumnos = IngresarEntero("Ingrese la cantidad de alumnos en el curso");
    int recaudacionCurso = 0;

    for(int i = 0; i < alumnos; i++)
    {
        recaudacionCurso+= IngresarEntero("Ingrese el dinero a aportar:");
    }
    dicRecaudacion.Add(curso, recaudacionCurso);
}

int IngresarEntero(string msg)
    {
        Console.WriteLine(msg);
        int num = int.Parse(Console.ReadLine());
        return num;
    }

char IngresarChar(string msg)
    {
        Console.WriteLine(msg);
        char Char = char.Parse(Console.ReadLine());
        return Char;
    }

string IngresarTexto(string msg)
    {
        Console.WriteLine(msg);
        string a = Console.ReadLine();
        return a;
    }

void Estadisticas()
{
    int acum = 0;
    int cantCursos = 0;
    int max = 0;
    char cursoMax = ' ';
    foreach(char clave in dicRecaudacion.Keys)
    {
        acum += dicRecaudacion[clave];
        cantCursos++;
        if(dicRecaudacion[clave] > max)
        {
            max = dicRecaudacion[clave];
            cursoMax = clave;
        }
    }
    int promedio = acum/cantCursos;
    Console.WriteLine($"El curso que mas plata puso fue el {cursoMax}");
    Console.WriteLine($"El promedio de plata regalado por todos los cursos es de {promedio}$"); 
    Console.WriteLine($"La recaudacion total fue de {acum}$");
    Console.WriteLine($"Los cursos que participan del regalo son {cantCursos}");
}

string ValidarRespuesta()
{
    string respuestaUser;

    respuestaUser = IngresarTexto("Desea ver estadisticas/recaudar? [ESTADISTICAS/RECAUDAR/FIN]");

    while(respuestaUser != "FIN" && respuestaUser != "RECAUDAR" && respuestaUser != "ESTADISTICAS")
    {
        respuestaUser = IngresarTexto("Ingrese una de estas opciones [ESTADISTICAS/RECAUDAR/FIN]");
    }
    return respuestaUser;
}