import { React, Component } from 'react';
import axios from "axios";
import { parseJwt, usuarioAutenticado } from '../../services/auth/auth';

import logo_spmed from "../../assets/Imagem_logo.png"
import circulo from "../../assets/circulo.png"

export default class Consultas extends Component {

    constructor(props) {
        super(props)
        this.state = {
            listaConsultas: [],

        }
    }

    redirecionarPara = (path) => {
        this.props.history.push(path.target.name)
    }

    efetuarLogout = () => {
        localStorage.removeItem('usuario-login')
        this.props.history.push('/login')
    }

    async listarConsultasPaciente() {
        await axios('http://localhost:5000/api/Consultas/pac/' + parseJwt().email, {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
            },
        })
            .then(resposta => {
                if (resposta.status == 200) {
                    this.setState({ listaConsultas: resposta.data })
                };
            })

            .catch(erro => console.log(erro))
    }

    componentDidMount() {
        this.listarConsultasPaciente();
    }

    render() {

        let navPage = []

        for (let i = 0; i < this.state.navLength; i++) {
            navPage.push(i + 1)
        }

        return (
            <div>
                <header className="container">
                    <img src={logo_spmed} alt="Logo SPMedicalGroup" />
                    <nav>
                        <a name="/" onClick={this.redirecionarPara}>Home</a>
                        {
                            usuarioAutenticado() ?
                                parseJwt().role === 'ADM' ?
                                    <a name="/consultas" onClick={this.redirecionarPara} >Consultas</a> :

                                    parseJwt().role === 'MED' ?
                                        <a name="/consultas-medico" onClick={this.redirecionarPara} >Consultas</a> :

                                        parseJwt().role === 'PAC' ?
                                            <a name="/consultas-paciente" onClick={this.redirecionarPara} >Consultas</a> :
                                            null : null
                        }
                        {
                            usuarioAutenticado()
                                ? <button id="deslogar" name="/login" onClick={this.efetuarLogout} >Desconectar</button>
                                : <button id="logar" name="/login" onClick={this.redirecionarPara} >Conectar</button>

                        }
                    </nav>
                </header>

                <main className="main-consultas container">
                    <h1>Consultas</h1>
                    <hr />
                    <div className="consultas-section consultas-section-pac">

                        <section className="listar">
                            {
                                this.state.listaConsultas.map(x => {
                                    return (
                                        <article>
                                            <div className="nomes-consulta">
                                                <img src={circulo} alt="" />
                                                <div className="nomes-div">
                                                    <p>Dr. {x.idMedicoNavigation.nomeMed}</p>
                                                    <span>{x.idPacienteNavigation.nomePac}</span>
                                                </div>
                                            </div>

                                            <div className="hora-consulta">
                                                <p>{x.dataConsulta.split('T')[1].substring(0, 5)}</p>
                                                <span>{x.dataConsulta.split('T')[0]}</span>
                                            </div>
                                        </article>
                                    )
                                })
                            }
                        </section>
                    </div>
                </main>
            </div>
        )
    }
}