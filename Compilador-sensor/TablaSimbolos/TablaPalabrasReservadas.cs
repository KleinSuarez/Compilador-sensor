﻿using Compilador_sensor.Transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador_sensor.TablaSimbolos
{
    public class TablaPalabrasReservadas
    {
        private Dictionary<String, List<ComponenteLexico>> Tabla = new Dictionary<String, List<ComponenteLexico>>();

        private static TablaPalabrasReservadas INSTANCIA = new TablaPalabrasReservadas();
        private TablaPalabrasReservadas()
        {

        }

        public static TablaPalabrasReservadas ObtenerInstancia()
        {
            return INSTANCIA;
        }

        public void Limpiar()
        {
            Tabla.Clear();
        }

        private List<ComponenteLexico> ObtenerSimbolo(string Simbolo)
        {
            if (!Tabla.ContainsKey(Simbolo))
            {
                Tabla.Add(Simbolo, new List<ComponenteLexico>());
            }

            return Tabla[Simbolo];
        }

        public void Agregar(ComponenteLexico Componente)
        {
            if (Componente != null && Tipo.PALABRA_RESERVADA.Equals(Componente.ObtenerTipo()))
            {
                ObtenerSimbolo(Componente.ObtenerLexema()).Add(Componente);
            }
        }

        public List<ComponenteLexico> ObtenerComponentes()
        {
            List<ComponenteLexico> Componentes = new List<ComponenteLexico>();

            foreach (List<ComponenteLexico> Lista in Tabla.Values)
            {
                Componentes.AddRange(Lista);
            }

            return Componentes;
        }
    }
}