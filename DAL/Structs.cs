


using System;
using SubSonic.Schema;
using System.Collections.Generic;
using SubSonic.DataProviders;
using System.Data;

namespace DAL {
	
        /// <summary>
        /// Table: Operaciones
        /// Primary Key: Operacion
        /// </summary>

        public class OperacionesTable: DatabaseTable {
            
            public OperacionesTable(IDataProvider provider):base("Operaciones",provider){
                ClassName = "Operacione";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("Operacion", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });
                    
                
                
            }
            
            public IColumn Operacion{
                get{
                    return this.GetColumn("Operacion");
                }
            }
				
   			public static string OperacionColumn{
			      get{
        			return "Operacion";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: sqlite_sequence
        /// Primary Key: 
        /// </summary>

        public class sqlite_sequenceTable: DatabaseTable {
            
            public sqlite_sequenceTable(IDataProvider provider):base("sqlite_sequence",provider){
                ClassName = "sqlite_sequence";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("seq", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });
                    
                
                
            }
            
            public IColumn name{
                get{
                    return this.GetColumn("name");
                }
            }
				
   			public static string nameColumn{
			      get{
        			return "name";
      			}
		    }
            
            public IColumn seq{
                get{
                    return this.GetColumn("seq");
                }
            }
				
   			public static string seqColumn{
			      get{
        			return "seq";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: Paises
        /// Primary Key: Pais
        /// </summary>

        public class PaisesTable: DatabaseTable {
            
            public PaisesTable(IDataProvider provider):base("Paises",provider){
                ClassName = "Paise";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("Pais", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });
                    
                
                
            }
            
            public IColumn Pais{
                get{
                    return this.GetColumn("Pais");
                }
            }
				
   			public static string PaisColumn{
			      get{
        			return "Pais";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: Estados
        /// Primary Key: Id
        /// </summary>

        public class EstadosTable: DatabaseTable {
            
            public EstadosTable(IDataProvider provider):base("Estados",provider){
                ClassName = "Estado";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("Pais", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("State", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
            
            public IColumn Pais{
                get{
                    return this.GetColumn("Pais");
                }
            }
				
   			public static string PaisColumn{
			      get{
        			return "Pais";
      			}
		    }
            
            public IColumn State{
                get{
                    return this.GetColumn("State");
                }
            }
				
   			public static string StateColumn{
			      get{
        			return "State";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: Calificaciones
        /// Primary Key: Calificacion
        /// </summary>

        public class CalificacionesTable: DatabaseTable {
            
            public CalificacionesTable(IDataProvider provider):base("Calificaciones",provider){
                ClassName = "Calificacione";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("Calificacion", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });
                    
                
                
            }
            
            public IColumn Calificacion{
                get{
                    return this.GetColumn("Calificacion");
                }
            }
				
   			public static string CalificacionColumn{
			      get{
        			return "Calificacion";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: Mensajerias
        /// Primary Key: MensajeriaName
        /// </summary>

        public class MensajeriasTable: DatabaseTable {
            
            public MensajeriasTable(IDataProvider provider):base("Mensajerias",provider){
                ClassName = "Mensajeria";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("MensajeriaName", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });
                    
                
                
            }
            
            public IColumn MensajeriaName{
                get{
                    return this.GetColumn("MensajeriaName");
                }
            }
				
   			public static string MensajeriaNameColumn{
			      get{
        			return "MensajeriaName";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: Busquedas
        /// Primary Key: Tipo
        /// </summary>

        public class BusquedasTable: DatabaseTable {
            
            public BusquedasTable(IDataProvider provider):base("Busquedas",provider){
                ClassName = "Busqueda";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("Tipo", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("Categoria", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });
                    
                
                
            }
            
            public IColumn Tipo{
                get{
                    return this.GetColumn("Tipo");
                }
            }
				
   			public static string TipoColumn{
			      get{
        			return "Tipo";
      			}
		    }
            
            public IColumn Categoria{
                get{
                    return this.GetColumn("Categoria");
                }
            }
				
   			public static string CategoriaColumn{
			      get{
        			return "Categoria";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: Usuarios
        /// Primary Key: Seudonimo
        /// </summary>

        public class UsuariosTable: DatabaseTable {
            
            public UsuariosTable(IDataProvider provider):base("Usuarios",provider){
                ClassName = "Usuario";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("Seudonimo", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("Mail", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 150
                });

                Columns.Add(new DatabaseColumn("Nombre", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("ApPaterno", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("ApMaterno", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("Direccion", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 200
                });

                Columns.Add(new DatabaseColumn("CP", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6
                });

                Columns.Add(new DatabaseColumn("Colonia", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("Tel_Casa", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 15
                });

                Columns.Add(new DatabaseColumn("Tel_Cel", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10
                });

                Columns.Add(new DatabaseColumn("Pais", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("Estado", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("Ciudad", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("FchAlta", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });
                    
                
                
            }
            
            public IColumn Seudonimo{
                get{
                    return this.GetColumn("Seudonimo");
                }
            }
				
   			public static string SeudonimoColumn{
			      get{
        			return "Seudonimo";
      			}
		    }
            
            public IColumn Mail{
                get{
                    return this.GetColumn("Mail");
                }
            }
				
   			public static string MailColumn{
			      get{
        			return "Mail";
      			}
		    }
            
            public IColumn Nombre{
                get{
                    return this.GetColumn("Nombre");
                }
            }
				
   			public static string NombreColumn{
			      get{
        			return "Nombre";
      			}
		    }
            
            public IColumn ApPaterno{
                get{
                    return this.GetColumn("ApPaterno");
                }
            }
				
   			public static string ApPaternoColumn{
			      get{
        			return "ApPaterno";
      			}
		    }
            
            public IColumn ApMaterno{
                get{
                    return this.GetColumn("ApMaterno");
                }
            }
				
   			public static string ApMaternoColumn{
			      get{
        			return "ApMaterno";
      			}
		    }
            
            public IColumn Direccion{
                get{
                    return this.GetColumn("Direccion");
                }
            }
				
   			public static string DireccionColumn{
			      get{
        			return "Direccion";
      			}
		    }
            
            public IColumn CP{
                get{
                    return this.GetColumn("CP");
                }
            }
				
   			public static string CPColumn{
			      get{
        			return "CP";
      			}
		    }
            
            public IColumn Colonia{
                get{
                    return this.GetColumn("Colonia");
                }
            }
				
   			public static string ColoniaColumn{
			      get{
        			return "Colonia";
      			}
		    }
            
            public IColumn Tel_Casa{
                get{
                    return this.GetColumn("Tel_Casa");
                }
            }
				
   			public static string Tel_CasaColumn{
			      get{
        			return "Tel_Casa";
      			}
		    }
            
            public IColumn Tel_Cel{
                get{
                    return this.GetColumn("Tel_Cel");
                }
            }
				
   			public static string Tel_CelColumn{
			      get{
        			return "Tel_Cel";
      			}
		    }
            
            public IColumn Pais{
                get{
                    return this.GetColumn("Pais");
                }
            }
				
   			public static string PaisColumn{
			      get{
        			return "Pais";
      			}
		    }
            
            public IColumn Estado{
                get{
                    return this.GetColumn("Estado");
                }
            }
				
   			public static string EstadoColumn{
			      get{
        			return "Estado";
      			}
		    }
            
            public IColumn Ciudad{
                get{
                    return this.GetColumn("Ciudad");
                }
            }
				
   			public static string CiudadColumn{
			      get{
        			return "Ciudad";
      			}
		    }
            
            public IColumn FchAlta{
                get{
                    return this.GetColumn("FchAlta");
                }
            }
				
   			public static string FchAltaColumn{
			      get{
        			return "FchAlta";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: MenuPrincipal
        /// Primary Key: Id_Menu
        /// </summary>

        public class MenuPrincipalTable: DatabaseTable {
            
            public MenuPrincipalTable(IDataProvider provider):base("MenuPrincipal",provider){
                ClassName = "MenuPrincipal";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("Id_Menu", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("Opciontxt", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });
                    
                
                
            }
            
            public IColumn Id_Menu{
                get{
                    return this.GetColumn("Id_Menu");
                }
            }
				
   			public static string Id_MenuColumn{
			      get{
        			return "Id_Menu";
      			}
		    }
            
            public IColumn Opciontxt{
                get{
                    return this.GetColumn("Opciontxt");
                }
            }
				
   			public static string OpciontxtColumn{
			      get{
        			return "Opciontxt";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: Transacciones
        /// Primary Key: Id_Tran
        /// </summary>

        public class TransaccionesTable: DatabaseTable {
            
            public TransaccionesTable(IDataProvider provider):base("Transacciones",provider){
                ClassName = "Transaccione";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("Id_Tran", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("FchAlta", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("Seudonimo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("Tipo_Op", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("FchCompraVenta", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("Dsc", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 250
                });

                Columns.Add(new DatabaseColumn("Estatus", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Calif_Recib", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Calif_Otorg", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Mensajeria", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("NumGuia", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 35
                });

                Columns.Add(new DatabaseColumn("Cantidad", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Double,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("Precio", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Double,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("PrecioEnvio", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Double,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("Total", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Double,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });
                    
                
                
            }
            
            public IColumn Id_Tran{
                get{
                    return this.GetColumn("Id_Tran");
                }
            }
				
   			public static string Id_TranColumn{
			      get{
        			return "Id_Tran";
      			}
		    }
            
            public IColumn FchAlta{
                get{
                    return this.GetColumn("FchAlta");
                }
            }
				
   			public static string FchAltaColumn{
			      get{
        			return "FchAlta";
      			}
		    }
            
            public IColumn Seudonimo{
                get{
                    return this.GetColumn("Seudonimo");
                }
            }
				
   			public static string SeudonimoColumn{
			      get{
        			return "Seudonimo";
      			}
		    }
            
            public IColumn Tipo_Op{
                get{
                    return this.GetColumn("Tipo_Op");
                }
            }
				
   			public static string Tipo_OpColumn{
			      get{
        			return "Tipo_Op";
      			}
		    }
            
            public IColumn FchCompraVenta{
                get{
                    return this.GetColumn("FchCompraVenta");
                }
            }
				
   			public static string FchCompraVentaColumn{
			      get{
        			return "FchCompraVenta";
      			}
		    }
            
            public IColumn Dsc{
                get{
                    return this.GetColumn("Dsc");
                }
            }
				
   			public static string DscColumn{
			      get{
        			return "Dsc";
      			}
		    }
            
            public IColumn Estatus{
                get{
                    return this.GetColumn("Estatus");
                }
            }
				
   			public static string EstatusColumn{
			      get{
        			return "Estatus";
      			}
		    }
            
            public IColumn Calif_Recib{
                get{
                    return this.GetColumn("Calif_Recib");
                }
            }
				
   			public static string Calif_RecibColumn{
			      get{
        			return "Calif_Recib";
      			}
		    }
            
            public IColumn Calif_Otorg{
                get{
                    return this.GetColumn("Calif_Otorg");
                }
            }
				
   			public static string Calif_OtorgColumn{
			      get{
        			return "Calif_Otorg";
      			}
		    }
            
            public IColumn Mensajeria{
                get{
                    return this.GetColumn("Mensajeria");
                }
            }
				
   			public static string MensajeriaColumn{
			      get{
        			return "Mensajeria";
      			}
		    }
            
            public IColumn NumGuia{
                get{
                    return this.GetColumn("NumGuia");
                }
            }
				
   			public static string NumGuiaColumn{
			      get{
        			return "NumGuia";
      			}
		    }
            
            public IColumn Cantidad{
                get{
                    return this.GetColumn("Cantidad");
                }
            }
				
   			public static string CantidadColumn{
			      get{
        			return "Cantidad";
      			}
		    }
            
            public IColumn Precio{
                get{
                    return this.GetColumn("Precio");
                }
            }
				
   			public static string PrecioColumn{
			      get{
        			return "Precio";
      			}
		    }
            
            public IColumn PrecioEnvio{
                get{
                    return this.GetColumn("PrecioEnvio");
                }
            }
				
   			public static string PrecioEnvioColumn{
			      get{
        			return "PrecioEnvio";
      			}
		    }
            
            public IColumn Total{
                get{
                    return this.GetColumn("Total");
                }
            }
				
   			public static string TotalColumn{
			      get{
        			return "Total";
      			}
		    }
            
                    
        }
        
}