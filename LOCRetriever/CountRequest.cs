using System;
using System.Collections.Generic;

namespace LOCRetriever
{
    public class CountRequest
    {
        public string OrganizationIdentifier { get; set; }
        public string RepositoryIdentifier { get; set; }
        public List<string> Branches { get; set; }
        public List<Requirement> Requirements { get; set; }        
        public CommitIgnoreObject CommitIgnore { get; set; }
        public FileIgnoreObject FileIgnore { get; set; }

        public CountRequest()
        {
            CommitIgnore = new CommitIgnoreObject
            {
                CommitExclusionType = ExclusionType.ExcludeThese,
                CommitIgnoreList = new List<string> {
                    "merge", //Commits que contengan merge.
                    "SinReq" //Commits que no están relacionados a ningún requerimiento.                    
                }
            };

            FileIgnore = new FileIgnoreObject
            {
                FileExclusionType = ExclusionType.ExcludeThese,
                FileExtensionIgnoreList = new List<string> {
                    ".orig", //Archivos que corresponden a un archivo original del controlador de versiones.
                    ".gitignore", //Archivos propios del controlador de versiones.
                    ".csproj", //Configuración de proyecto.                    
                    ".user", //Configuración de proyecto por usuario (csproj.user).
                    ".sln", //Soluciones de visual studio.
                    ".SVG", //Imágenes de tipo SVG.
                    ".wsdl" //Proxy correspondientes a Webservices.
                },
                FileNameIgnoreList = new List<string> {
                    "README.md", //Archivos de tipo README.            
                    "Reference.cs", //Referencia de web services.            
                    "LICENSE" //Archivos de tipo licencia.            
                }
            };

            Requirements = new List<Requirement>();
        }
    }
}
