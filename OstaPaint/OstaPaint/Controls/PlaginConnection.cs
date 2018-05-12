using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstFigures;
using System.Reflection;
using System.Windows.Forms;

namespace OstaPaint.Controls
{
    class PlaginConnection
    {
        private List<Type> pluginTypes;
        public String dllPath;
        public List<Type> Plagins
        {
            get
            {
                return pluginTypes;
            }
            private set
            {
                pluginTypes = value;
            }
        }

        public PlaginConnection()
        {
            pluginTypes = new List<Type>();
        }
        public void getDllPath()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "dll файлы (*.dll) | *.dll";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                dllPath = dialog.FileName;
            }
        }

        private List<Type> getPluginTypes(Assembly assembly)
        {
            return assembly.GetTypes()
                .Where(x => x.GetInterface
                    (typeof(iPlagin).Name) != null)
                .ToList<Type>();
        }

        public void LoadPlugin(string FileName)
        {
            try
            {
                Assembly pluginAssembly = Assembly.LoadFrom(FileName);
                List<Type> pluginTypes = getPluginTypes(pluginAssembly);
                if (pluginTypes == null)
                {
                    DialogResult result = MessageBox.Show("Сборка содержит некорректные фигуры", "Ошибка", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        return;
                    }

                }

                //this.pluginTypes.Sort();
                foreach (Type x in pluginTypes)
                {
                    if (x.IsSubclassOf(typeof(Shape)) && x.IsPublic)
                    {
                        if (!(this.pluginTypes.Contains(x)))
                            this.pluginTypes.Add(x);
                    }
                }
            } catch(Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.ToString(), "Хуйня", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    return;
                }
            }
        }

        public Shape CreateInstance(int index)
        {
            Type figure_type = pluginTypes[index];
            return Activator.CreateInstance(figure_type) as Shape;
    }
    }
}
