using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using puntoVenta;
using puntoVenta.modulo_facturacion;
using puntoVenta;

namespace puntoVenta
{
    public partial class principal : Form
    {
        public string codigo_usuario;
        internal singleton s { get; set; }
        public principal()
        {
            InitializeComponent();
        }
        public void cargar_permisos_por_usuarios()
        {
            try
            {
                if (s.codigo_usuario.ToString()!="1")
                {
                    string sql = "";
                    DataSet ds = new DataSet();
                    if (s.codigo_usuario.ToString() != "1")
                    {
                        s = singleton.obtenerDatos();
                        //puede facturar
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='1' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.facturacion = true;
                        }
                        else
                        {
                            btn_facturacion.BackColor = Color.Black;
                            btn_facturacion.Enabled = false;
                        }
                        //puede crear y modificar productos
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='2' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.puede_crear_modificar_productos = true;
                        }
                        else
                        {
                            button8.Enabled = false;
                        }
                        //buscar existencia
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='3' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.puede_buscar_existencias = true;
                        }
                        else
                        {
                            button32.Enabled = false;
                        }
                        //anular pagos
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='4' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.anular_pagos_compras = true;
                        }
                        //cambio precio en facturacion
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='5' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.puede_Cambiar_precio_facturacion = true;
                        }
                        //puede comprar
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='6' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.hacer_compra = true;
                        }
                        else
                        {
                            btn_compras1.BackColor = Color.Black;
                            btn_compras2.BackColor = Color.Black;
                            btn_compras1.Enabled = false;
                            btn_compras2.Enabled = false;
                        }
                        //anular compra
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='7' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.anular_compra = true;
                        }
                        //anular facturas en venta
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='8' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.puede_anular_facturas_venta = true;
                        }
                        //puede poner credito al cliente
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='10' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.puede_poner_credito_cliente = true;
                        }
                        //puede hacer entrada y salida de productos
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='12' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.puede_entrada_salida_productos = true;
                            
                        }
                        else
                        {
                            button49.BackColor = Color.Black;
                            button49.Enabled=false;
                        }
                        //modulo inventario
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='14' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.mod_inventario = true;
                        }
                        else
                        {
                            TabControl1.TabPages.Remove(inventario_tab_txt);
                        }
                        //modulo cuentas por pagar
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='15' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.mod_cuentasPorPagar = true;
                        }
                        else
                        {
                            TabControl1.TabPages.Remove(cuenta_por_pagar_tab_txt);
                        }
                        //modulo cuentas por cobrar
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='16' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.mod_cuentasPorCobrar = true;
                        }
                        else
                        {
                            TabControl1.TabPages.Remove(cuenta_por_cobrar_tab_txt);
                        }
                        //modulo nomina
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='17' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.mod_nomina = true;
                        }
                        else
                        {
                            TabControl1.TabPages.Remove(nomina_tab_txt);
                        }
                        //modulo  facturacion
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='18' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.mod_facturacion = true;
                        }
                        else
                        {
                            TabControl1.TabPages.Remove(facturacion_tab_txt);
                        }
                        //modulo empresa
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='19' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.mod_empresa = true;
                        }
                        else
                        {
                            TabControl1.TabPages.Remove(empresa_tab_txt);
                        }
                        //modulo opciones
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='20' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.mod_opciones = true;
                        }
                        else
                        {
                            TabControl1.TabPages.Remove(opciones_tab_txt);
                        }
                        //modulo prestamos
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='21' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.mod_prestamos = true;
                        }
                        else
                        {
                            TabControl1.TabPages.Remove(prestamos_tab_txt);
                        }
                        //crear y modificar sucursales
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='22' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.puede_crear_modificar_sucursales = true;
                            button10.Enabled = true;
                        }
                        else
                        {
                            button10.BackColor = Color.Black;
                            button10.Enabled = false;
                        }
                        //cambiar clave
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='23' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.puede_cambiar_clave = true;
                            button15.Enabled = true;
                        }
                        else
                        {
                            button15.BackColor = Color.Black;
                            button15.Enabled = false;
                        }
                        //puede ver las ventas del dia
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='24' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.puede_ver_ventas_del_dia = true;
                            button52.Enabled = true;
                        }
                        else
                        {
                            button52.BackColor = Color.Black;
                            button52.Enabled = false;
                        }

                        //devolucion compra
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='25' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.devolucion_compra = true;
                        }
                        else
                        {
                            btn_devolucion_compra.BackColor = Color.Black;
                            btn_devolucion_compra.Enabled = false;
                        }
                        //puede hacer observacion a empleado
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='26' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.puede_hacer_observacion_empleado = true;
                        }
                        else
                        {
                            button30.BackColor = Color.Black;
                            button30.Enabled = false;
                        }
                        //puede hacer pagos a suplidores
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='27' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.puede_hacer_pagos_suplidores = true;
                        }
                        else
                        {
                            button16.BackColor = Color.Black;
                            button16.Enabled = false;
                        }
                        //puede cambiar fecha en facturacion
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='28' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.cambiar_fecha_facturacion = true;
                        }
                        //puede hacer cobros cxc
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='29' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.cobros_cxc = true;
                        }
                        else
                        {
                            btn_cobros.BackColor = Color.Black;
                            btn_cobros.Enabled = false;
                        }
                        //devolucion venta
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='30' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.devolucion_venta = true;
                        }
                        else
                        {
                            btn_devolucion_ventas.BackColor = Color.Black;
                            btn_devolucion_ventas.Enabled = false;
                        }
                        //puede poner precio a unidades productos
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='31' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.precio_producto_unidad = true;
                        }
                        else
                        {
                            btn_precio_productos_unidades.BackColor = Color.Black;
                            btn_precio_productos_unidades.Enabled = false;
                        }
                        //modulo administrador
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='32' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.mod_administrador = true;
                        }
                        else
                        {
                            TabControl1.TabPages.Remove(administrador_tab_txt);
                        }
                        //anular cobros de clientes
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='33' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.anular_cobros = true;
                        }

                       
                        //cambiar fecha en cuadre de caja
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='34' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.cambiaf_fecha_cuadre_caja = true;
                        }
                        //puede asignar permisos
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='35' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.puede_asignar_permisos = true;
                        }
                        //puede asignar permisos a grupos
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='36' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.puede_asignar_permisos_a_grupos = true;
                        }
                        //puede hacer cuadre de caja
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='37' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.puede_hacer_cuadre_caja = true;
                        }
                        else
                        {
                            button34.Enabled = false;
                        }
                        //puede autorizar pedidos
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='38' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.puede_autorizar_pedidos = true;
                        }
                        //puede despachar o dar salida a pedidos
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='39' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.puede_despachar_pedidos = true;
                        }
                        //puede anular pedidos
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='40' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.puede_anular_pedidos = true;
                        }
                        //puede crear pedidos
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='41' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.puede_crear_pedidos = true;
                        }
                        //puede cambiar fecha en egresos de caja
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='42' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.puede_cambiar_fecha_en_egreso_caja = true;
                        }
                        //puede hacer en egresos de caja
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='43' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.puede_crear_egresos_caja = true;
                        }
                        //puede crear y modificar empleados
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='44' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.puede_crear_modificar_empleados = true;
                        }
                        else
                        {
                            button4.BackColor = Color.Black;
                            button4.Enabled = false;
                        }
                        //puede crear y modificar empleados
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='45' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.puede_modificar_sistema = true;
                        }
                        else
                        {
                            button42.BackColor = Color.Black;
                            button42.Enabled = false;
                        }
                        //puede crear y modificar empresa
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='46' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.puede_crear_modificar_empresas = true;
                        }
                        else
                        {
                            button14.BackColor = Color.Black;
                            button14.Enabled = false;
                        }
                        //puede GENERAR LA NOMINA
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='47' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.puede_generar_nomina = true;
                        }
                        else
                        {
                            button59.BackColor = Color.Black;
                            button59.Enabled = false;
                        }
                        //puede hacer ingresos a caja
                        sql = "select *from tercero_vs_permiso where cod_tercero='" + s.codigo_usuario.ToString() + "' and cod_permiso='48' and tipo_entidad='EMP' and estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            s.puede_hacer_ingresos_caja = true;
                        }
                        else
                        {
                            button11.BackColor = Color.Black;
                            button11.Enabled = false;
                        }
                       
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error sacando los permisos del usuario");
            }
        }
        
        private void principal_Load(object sender, EventArgs e)
        {
            string sql ="";
            DataSet ds = new DataSet();
            try
            {
                //tabControl1.TabPages.RemoveAt(6); //para eliminar una pestana del tab control con la 6 se va un numero mas
                //tabControl1.Controls.Remove(inventario_tab_txt.Hide);
                //this.Location = Screen.PrimaryScreen.WorkingArea.Location;
                //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
                s = singleton.obtenerDatos();
                //MessageBox.Show("codigo usuario->" + s.codigo_usuario.ToString());
                if (s.codigo_usuario.ToString() != "1")
                {

                    //saber si se cargaran los permisos por grupos o permisos individuales
                    sql = "select permisos_por_grupos_usuarios from sistema where codigo='1'";
                    ds = Utilidades.ejecutarcomando(sql);
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        cargar_permisos_grupo();   
                    }
                    else
                    {
                        cargar_permisos_por_usuarios();
                    }
                }
               
                if (s.codigo_sucursal.ToString() != "")
                {
                    sql = "select nombre from tercero where codigo='" + s.codigo_sucursal.ToString() + "'";
                    ds = Utilidades.ejecutarcomando(sql);
                    sucursal_label.Text = s.nombre.ToString()+"-"+ds.Tables[0].Rows[0]["nombre"].ToString();
                    sql = "select codigo_empresa from sucursal where codigo='" + s.codigo_sucursal.ToString() + "'";
                    ds = Utilidades.ejecutarcomando(sql);
                    s.codigo_empresa = ds.Tables[0].Rows[0][0].ToString();

                    //sacando la imagen de la empresa
                    sql = "select top(1) ruta_imagen_productos,ruta_logo_empresa from sistema";
                    ds = Utilidades.ejecutarcomando(sql);
                    string logo_empresa = ds.Tables[0].Rows[0][0].ToString();
                    logo_empresa += @"\" + ds.Tables[0].Rows[0][1].ToString();
                    panel3.BackgroundImage = Image.FromFile(logo_empresa.ToString());
                }
                //if (s.idioma.ToString() == "en-EN")
                //{
                //    //punto_de_venta_lbl.Text = i18n.punto_de_venta_en.ToString();
                //    almacen_label.Text = proyecto.archivos.i18n.almacen_en.ToString();
                //    producto_label.Text = proyecto.archivos.i18n.producto_en.ToString();
                   

                //    compras_label.Text = proyecto.archivos.i18n.compras_en.ToString();
                //    consulta_compras_label.Text = proyecto.archivos.i18n.consulta_compras_en.ToString();
                //    existencia_label.Text = proyecto.archivos.i18n.existencia_en.ToString();
                //    categoria_label.Text = proyecto.archivos.i18n.categorias_en.ToString();
                //    inventario_tab_txt.Text = proyecto.archivos.i18n.inventario_en.ToString();
                //}
                //if (s.idioma.ToString() == "es-ES")
                //{
                //    //punto_de_venta_lbl.Text = i18n.punto_de_venta_es.ToString();
                //    almacen_label.Text = proyecto.archivos.i18n.almacen_es.ToString();
                //    producto_label.Text = proyecto.archivos.i18n.producto_es.ToString();
                   

                //    compras_label.Text = proyecto.archivos.i18n.compras_es.ToString();
                //    consulta_compras_label.Text = proyecto.archivos.i18n.consulta_compras_es.ToString();
                //    existencia_label.Text = proyecto.archivos.i18n.existencia_es.ToString();
                //    categoria_label.Text = proyecto.archivos.i18n.categorias_es.ToString();
                //    inventario_tab_txt.Text = proyecto.archivos.i18n.inventario_es.ToString();
                //}
            }
            catch(Exception)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            
            //MessageBox.Show(s.codigo_usuario);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Deseas salir?", "Saliendo", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(dr==DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void usuario_label_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            empleado em = new empleado();
            em.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cargo c = new cargo();
            c.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            direccion d = new direccion();
            d.ShowDialog();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            if (s.facturacion == true)
            {
                facturacion f = new facturacion();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("El usuario no tiene habilitado el permiso para poder facturar");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            producto p = new producto();
            p.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            sucursal s = new sucursal();
            s.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            cliente c = new cliente();
            c.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            sexo s = new sexo();
            s.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            movimiento_inventario i = new movimiento_inventario();
            i.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            cuenta_por_cobrar cc = new cuenta_por_cobrar();
            cc.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            cambiar_clave c = new cambiar_clave();
            c.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            empresa em = new empresa();
            em.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            cuenta_por_pagar_suplidores cp = new cuenta_por_pagar_suplidores();
            cp.ShowDialog();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            almacen al = new almacen();
            al.ShowDialog();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            situacion_empleado s = new situacion_empleado();
            s.ShowDialog();
        }

        private void button19_Click(object sender, EventArgs e)
        {
          
        }

        private void button20_Click(object sender, EventArgs e)
        {
            suplidores s = new suplidores();
            s.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)
        {
        }

        private void button21_Click(object sender, EventArgs e)
        {
            busqueda_factura bf = new busqueda_factura();
            bf.ShowDialog();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            compra cp = new compra();
            cp.ShowDialog();
        }

        private void button23_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click_1(object sender, EventArgs e)
        {
            busqueda_compras bc = new busqueda_compras();
            bc.ShowDialog();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            cliente_estado ce = new cliente_estado();
            ce.ShowDialog();
        }

        private void button26_Click_1(object sender, EventArgs e)
        {
            busqueda_compras bc = new busqueda_compras();
            bc.ShowDialog();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            comprobante_fiscal c = new comprobante_fiscal();
            c.ShowDialog();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            compra c = new compra();
            c.ShowDialog();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            caja ca = new caja();
            ca.ShowDialog();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            observaciones_empleados o = new observaciones_empleados();
            o.ShowDialog();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            facturacion_flash f = new facturacion_flash();
            f.ShowDialog();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            busqueda_existencia be = new busqueda_existencia();
            be.ShowDialog();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button33_Click(object sender, EventArgs e)
        {
            categoria_subcategoria_producto c = new categoria_subcategoria_producto();
            c.ShowDialog();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            if (s.facturacion = true)
            {
                cuadre_caja cc = new cuadre_caja();
                cc.ShowDialog();
            }
            else
            {
                MessageBox.Show("El usuario no tiene habilitado el permiso para poder facturar, y no puede hacer cuadre de caja");
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            reporte_suplidor r = new reporte_suplidor();
            r.ShowDialog();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            reporte_cliente re = new reporte_cliente();
            re.ShowDialog();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            reporte_ventas re = new reporte_ventas();
            re.ShowDialog();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            compras_devolucion d = new compras_devolucion();
            d.ShowDialog();
            
        }

        private void button40_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Deseas cambiar de usuario?", "Cambiando de usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                login l = new login();
                l.Show();
                this.Close();
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            departamento d = new departamento();
            d.ShowDialog();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            //if el usuario tiene permiso para entrar en la configuracion del sistema
            puntoVenta s = new puntoVenta();
            s.ShowDialog();
        }

        private void button43_Click(object sender, EventArgs e)
        {
            prestamo p = new prestamo();
            p.Show();
        }

        private void button44_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void button27_Click_1(object sender, EventArgs e)
        {
            busqueda_unidad bu = new busqueda_unidad();
            bu.ShowDialog();
        }

        private void button44_Click_1(object sender, EventArgs e)
        {
            producto_detalle p = new producto_detalle();
            p.ShowDialog();
        }

        private void button45_Click(object sender, EventArgs e)
        {
            busqueda_pagos_compras b = new busqueda_pagos_compras();
            b.ShowDialog();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            cajeros c=new cajeros();
            c.ShowDialog();
        }

        private void button47_Click(object sender, EventArgs e)
        {
            sexo s = new sexo();
            s.ShowDialog();
        }

        private void button48_Click(object sender, EventArgs e)
        {
            categoria_subcatecoria_cliente c = new categoria_subcatecoria_cliente();
            c.ShowDialog();
        }

        private void button49_Click(object sender, EventArgs e)
        {
            entrada_salida_inventario es = new entrada_salida_inventario();
            es.ShowDialog();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            backup b = new backup();
            b.ShowDialog();
        }

        private void button51_Click(object sender, EventArgs e)
        {
            busqueda_cobros_venta bc = new busqueda_cobros_venta();
            bc.ShowDialog();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            devolucion_venta dv = new devolucion_venta();
            dv.ShowDialog();
        }

        private void button52_Click(object sender, EventArgs e)
        {
            ventas v = new ventas();
            v.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            dlrsoft d = new dlrsoft();
            d.ShowDialog();
        }

        private void button53_Click(object sender, EventArgs e)
        {
            itebis it = new itebis();
            it.ShowDialog();
        }

        private void button54_Click(object sender, EventArgs e)
        {
            cambiar_precio_producto cp = new cambiar_precio_producto();
            cp.ShowDialog();
        }

        private void button55_Click(object sender, EventArgs e)
        {
            busqueda_comprobantes_fiscales bc = new busqueda_comprobantes_fiscales();
            bc.ShowDialog();
        }

        private void button56_Click(object sender, EventArgs e)
        {
            modificar_factura mf = new modificar_factura();
            mf.ShowDialog();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            try
            {
                ventas_mensuales vm = new ventas_mensuales();
                vm.ShowDialog();
            }
            catch(Exception)
            {
                MessageBox.Show("Error abriendo ventana de impresion");
            }
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            ventas_productos vp = new ventas_productos();
            vp.ShowDialog();
        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            busqueda_entrada_salida_inventario iv = new busqueda_entrada_salida_inventario();
            iv.ShowDialog();
        }

        private void button24_Click_1(object sender, EventArgs e)
        {
            estado_resultado er = new estado_resultado();
            er.ShowDialog();
        }

        private void button35_Click_1(object sender, EventArgs e)
        {
            reporte_cliente rc = new reporte_cliente();
            rc.ShowDialog();
        }

        private void button36_Click_1(object sender, EventArgs e)
        {
            moneda mo = new moneda();
            mo.ShowDialog();
        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void button54_Click_1(object sender, EventArgs e)
        {
            grupo_usuarios gr = new grupo_usuarios();
            gr.ShowDialog();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }
        public void cargar_permisos_grupo()
        {
            s = singleton.obtenerDatos();
            string sql = "";
            DataSet ds = new DataSet();
            if (s.codigo_usuario != "1")
            {
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='29' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);



                //puede facturar
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='1' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.facturacion = true;
                }
                else
                {
                    btn_facturacion.BackColor = Color.Black;
                    btn_facturacion.Enabled = false;
                }
                //puede crear y modificar productos
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='2' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.puede_crear_modificar_productos = true;
                }
                else
                {
                    button8.BackColor = Color.Black;
                    button8.Enabled = false;
                }
                //buscar existencia
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='3' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.puede_buscar_existencias = true;
                }
                else
                {
                    button32.BackColor = Color.Black;
                    button32.Enabled = false;
                }
                //anular pagos a suplidores
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='4' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.anular_pagos_compras = true;
                }
                //puede cambiar precio en facturacion
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='5' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.puede_Cambiar_precio_facturacion = true;
                }
                //puede comprar
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='6' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.hacer_compra = true;
                }
                else
                {
                    btn_compras1.BackColor = Color.Black;
                    btn_compras2.BackColor = Color.Black;
                    btn_compras1.Enabled = false;
                    btn_compras2.Enabled = false;
                }
                //anular compra
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='7' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.anular_compra = true;
                }
              
              
                
               
               
                
                
                //anular pagos
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='4' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.anular_pagos_compras = true;
                }
                //puede anular compras
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='7' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.anular_compra = true;
                }
                //puede anular facturas en venta
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='8' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.puede_anular_facturas_venta = true;
                }
                //puede poner credito a cliente
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='10' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.puede_poner_credito_cliente = true;
                }
                //puede hacer entrada y salida de inventario
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='12' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.puede_entrada_salida_productos = true;
                }
                else
                {
                    button49.BackColor = Color.Black;
                    button49.Enabled = false;
                }
                //modulo inventario
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='14' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.mod_inventario = true;
                }
                else
                {
                    TabControl1.TabPages.Remove(inventario_tab_txt);
                }
                //modulo cuentas por pagar
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='15' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.mod_cuentasPorPagar = true;
                }
                else
                {
                    TabControl1.TabPages.Remove(cuenta_por_pagar_tab_txt);
                }
                //modulo cuentas por cobrar
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='16' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.mod_cuentasPorCobrar = true;
                }
                else
                {
                    TabControl1.TabPages.Remove(cuenta_por_cobrar_tab_txt);
                }
                //modulo nomina
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='17' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.mod_nomina = true;
                }
                else
                {
                    TabControl1.TabPages.Remove(nomina_tab_txt);
                }
                //modulo  facturacion
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='18' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.mod_facturacion = true;
                }
                else
                {
                    TabControl1.TabPages.Remove(facturacion_tab_txt);
                }
                //modulo empresa
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='19' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.mod_empresa = true;
                }
                else
                {
                    TabControl1.TabPages.Remove(empresa_tab_txt);
                }
                //modulo opciones
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='20' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.mod_opciones = true;
                }
                else
                {
                    TabControl1.TabPages.Remove(opciones_tab_txt);
                }
                //modulo prestamos
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='21' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.mod_prestamos = true;
                }
                else
                {
                    TabControl1.TabPages.Remove(prestamos_tab_txt);
                }
                //puede crear y modificar sucursales
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='22' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.puede_crear_modificar_sucursales = true;
                }
                else
                {
                    button10.BackColor = Color.Black;
                    button10.Enabled = false;
                }
                //puede cambiar clave de su usuario
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='23' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.puede_cambiar_clave = true;
                }
                else
                {
                    button15.BackColor = Color.Black;
                    button15.Enabled = false;
                }
                //puede ver as ventas del dia
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='24' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.puede_ver_ventas_del_dia = true;
                }
                else
                {
                    button52.BackColor = Color.Black;
                    button52.Enabled = false;
                }
                //devolucion compra
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='25' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.devolucion_compra = true;
                }
                else
                {
                    btn_devolucion_compra.BackColor = Color.Black;
                    btn_devolucion_compra.Enabled = false;
                }
                //puede hacer observacion a empleado
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='26' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.puede_hacer_observacion_empleado = true;
                }
                else
                {
                    button30.BackColor = Color.Black;
                    button30.Enabled = false;
                }
                //puede pagar a suplidores
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='27' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.puede_hacer_pagos_suplidores = true;
                }
                else
                {
                    button16.BackColor = Color.Black;
                    button16.Enabled = false;
                }
                //puede cambiar fecha en facturacion
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='28' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.cambiar_fecha_facturacion = true;
                }
                //puede hacer cobros cxc
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='29' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.cobros_cxc = true;
                }
                else
                {
                    btn_cobros.BackColor = Color.Black;
                    btn_cobros.Enabled = false;
                }
                //devolucion venta
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='30' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.devolucion_venta = true;
                }
                else
                {
                    btn_devolucion_ventas.BackColor = Color.Black;
                    btn_devolucion_ventas.Enabled = false;
                }
                //puede poner precio a unidades productos
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='31' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.precio_producto_unidad = true;
                }
                else
                {
                    btn_precio_productos_unidades.BackColor = Color.Black;
                    btn_precio_productos_unidades.Enabled = false;
                }
                //modulo administrador
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='32' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.mod_administrador = true;
                }
                else
                {
                    TabControl1.TabPages.Remove(administrador_tab_txt);
                }
                //anular cobros de clientes
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='33' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.anular_cobros = true;
                }

                
                //cambiar fecha en cuadre de caja
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='34' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.cambiaf_fecha_cuadre_caja = true;
                }
                //puede asignar permisos
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='35' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.puede_asignar_permisos = true;
                }
                //puede asignar permisos a grupos
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='36' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.puede_asignar_permisos_a_grupos = true;
                }
                //puede hacer cuadre de caja
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='37' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.puede_hacer_cuadre_caja = true;
                }
                else
                {
                    button34.BackColor = Color.Black;
                    button34.Enabled = false;
                }
                //puede autorizar pedidos
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='38' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.puede_autorizar_pedidos = true;
                }
                //puede despachar o dar salida a pedidos
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='39' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.puede_despachar_pedidos = true;
                } 
                //puede anular pedidos
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='40' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.puede_anular_pedidos = true;
                }
                //puede crear pedidos
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='41' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.puede_crear_pedidos = true;
                }
                //puede cambiar fecha en egresos de caja
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='42' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.puede_cambiar_fecha_en_egreso_caja = true;
                }
                //puede crear egresos de caja
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='43' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.puede_crear_egresos_caja = true;
                }
                //puede crear y modificar empleados
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='44' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.puede_crear_modificar_empleados = true;
                }
                else
                {
                    button4.BackColor = Color.Black;
                    button4.Enabled = false;
                }
                //puede modificar sistema
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='45' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.puede_modificar_sistema = true;
                }
                else
                {
                    button42.BackColor = Color.Black;
                    button42.Enabled = false;
                }
                //puede crear modificar empresas
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='46' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.puede_crear_modificar_empresas = true;
                }
                else
                {
                    button14.BackColor = Color.Black;
                    button14.Enabled = false;
                }
                //puege generar la nomina
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='47' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.puede_generar_nomina = true;
                }
                else
                {
                    button59.BackColor = Color.Black;
                    button59.Enabled = false;
                }

                //puede hacer ingresos a caja
                sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='48' and e.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s.puede_hacer_ingresos_caja = true;
                }
                else
                {
                    button11.BackColor = Color.Black;
                    button11.Enabled = false;
                }
               
            }
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            dlrsoft fl = new dlrsoft();
            fl.ShowDialog();
        }

        private void button57_Click(object sender, EventArgs e)
        {
            

        }

        private void button57_Click_1(object sender, EventArgs e)
        {
            mesas me = new mesas();
            me.ShowDialog();
        }

        private void button58_Click(object sender, EventArgs e)
        {
            vendedores ven = new vendedores();
            ven.ShowDialog();
        }

        private void nomina_tab_txt_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dlrsoft fl = new dlrsoft();
            fl.ShowDialog();
        }

        private void button59_Click(object sender, EventArgs e)
        {
            nomima no = new nomima();
            no.ShowDialog();
        }

        private void button60_Click(object sender, EventArgs e)
        {
            nomina_tipos nt = new nomina_tipos();
            nt.ShowDialog();
        }

        private void button61_Click(object sender, EventArgs e)
        {
            nomina_conceptos nc = new nomina_conceptos();
            nc.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            abrir_caja ac = new abrir_caja();
            ac.ShowDialog();
        }

        private void button63_Click(object sender, EventArgs e)
        {
            pedidos ped = new pedidos();
            ped.ShowDialog();
        }

        private void button64_Click(object sender, EventArgs e)
        {
            caja_egresos ec = new caja_egresos();
            ec.ShowDialog();
        }

        private void button65_Click(object sender, EventArgs e)
        {
            caja_egresos_conceptos cc = new caja_egresos_conceptos();
            cc.ShowDialog();
        }

        private void button66_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Deseas recargar los permisos?", "Recargando permisos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                principal p = new principal();
                p.Show();
                this.Close();
            }
        }

        private void label76_Click(object sender, EventArgs e)
        {

        }

        private void button67_Click(object sender, EventArgs e)
        {
            busqueda_vendedor_pedidos bvp = new busqueda_vendedor_pedidos();
            bvp.ShowDialog();
        }

        private void button68_Click(object sender, EventArgs e)
        {
            busqueda_cuadre_caja bc = new busqueda_cuadre_caja();
            bc.ShowDialog();
        }

        private void button69_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button62_Click(object sender, EventArgs e)
        {
           
        }

        private void button70_Click(object sender, EventArgs e)
        {
            productos_ofertas po = new productos_ofertas();
            po.ShowDialog();

            
        }

        private void button71_Click(object sender, EventArgs e)
        {
            
        }

        private void principal_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            imprimir_codigo_barra_productos ip = new imprimir_codigo_barra_productos();
            ip.ShowDialog();
            
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            caja_ingresos ci = new caja_ingresos();
            ci.ShowDialog();
        }

        private void button19_Click_1(object sender, EventArgs e)
        {
            caja_ingresos_conceptos ci = new caja_ingresos_conceptos();
            ci.ShowDialog();
        }

        private void button62_Click_1(object sender, EventArgs e)
        {
            sistema.correo_electronico correo = new sistema.correo_electronico();
            correo.ShowDialog();
        }

    }
}