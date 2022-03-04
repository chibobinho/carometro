import { Component } from "react";
import { parseJwt, usuarioAutenticado } from '../../services/auth/auth';

import logo_spmed from "../../assets/Imagem_logo.png"
import logo_spmed1 from "../../assets/logo_spmed.png"

export default class Home extends Component {
    
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
                <header class="container">
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
                            ? <button id="deslogar" name="/login" onClick={this.efetuarLogout} >Deslogar</button>
                            : <button id="logar" name="/login" onClick={this.redirecionarPara} >Logar</button>

                        }
                    </nav>
                </header>

                <main class="banner-home">
                    <div>
                        <img src={logo_spmed1} alt="Logo SPMedicalGroup" />
                        <span>A melhor clinica de São Paulo</span>
                    </div>
                </main>

                <footer>
                    <p>Escola Senai De Informática - 2021</p>
                </footer>
            </div >
        )
    }
}