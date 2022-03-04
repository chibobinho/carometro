import { React, Component } from 'react';
import axios from "axios";
import { parseJwt, usuarioAutenticado } from '../../services/auth/auth';
import CadastrarConsultas from '../../component/cadastrar';

import logo_spmed from "../../assets/Imagem_logo.png"
import circulo from "../../assets/circulo.png"


class ListarConsultas extends Component {

    constructor(props) {
        super(props)
        this.state = {
            listaConsultas: [],
        }
    }

    async listarConsultas() {
        await axios('http://localhost:5000/api/Consultas', {
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
        this.listarConsultas();
    }

    render() {
        let navPage = []

        for (let i = 0; i < this.state.navLength; i++) {
            navPage.push(i + 1)
        }

        return (
            <section className="listar">
                <div>
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
                                        <p>{Intl.DateTimeFormat("pt-BR", {
                                            hour: 'numeric', minute: 'numeric'
                                        }).format(new Date(x.dataConsulta))}</p>

                                        <span>{Intl.DateTimeFormat("pt-BR", {
                                            year: 'numeric', month: 'numeric', day: 'numeric',
                                        }).format(new Date(x.dataConsulta))}</span>
                                    </div>
                                </article>
                            )
                        })
                    }
                </div>

            </section>
        )
    }
}

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

    render() {
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
                    <div className="consultas-section">
                        <ListarConsultas />
                        <CadastrarConsultas />
                    </div>

                </main>
            </div>
        )
    }
}