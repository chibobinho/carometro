import React, { Component } from 'react';
import {
    SafeAreaView,
    ScrollView,
    StatusBar,
    StyleSheet,
    Text,
    ImageBackground,
    Image,
    TextInput,
    TouchableOpacity,
    View,
} from 'react-native';
import jwtDecode from 'jwt-decode';
import AsyncStorage from '@react-native-async-storage/async-storage';

export default class Perfil extends Component {

    constructor(props) {
        super(props);
        this.state = {
            username: '',
            role: '',
            email: '',
        };
    }

    buscarDadosPerfil = async () => {
        const valorToken = await AsyncStorage.getItem('userToken')

        if (valorToken != null) {
            this.setState({ email: jwtDecode(valorToken).email });
            this.setState({ username: jwtDecode(valorToken).username });
            this.setState({ role: jwtDecode(valorToken).role });
        }
    }

    tipoUsuario(role) {
        switch (role) {
            case 'ADM':
                return 'Administrador';
        
            case 'MED':
                return 'Médico';
            
            default:
                return 'Paciente'
        }
    }

    async componentDidMount() {
        this.buscarDadosPerfil()
    }

    render() {
        return (
            <View style={styles.Perfil}>
                
                <Image style={styles.perfilImg} source={require('../../assets/img/bg-cracha.png')} />

                <View style={styles.perfilInfo}>

                    <Text style={styles.username}>{this.state.username}</Text>
                    <Text style={styles.role}>{this.tipoUsuario(this.state.role)}</Text>
                    <View >
                        <Text style={styles.email}>{this.state.email}</Text>
                    </View>

                </View>

            </View>
        )
    }
}

const styles = StyleSheet.create({
    Perfil: {
        flex: 1,
        alignItems: 'center',
        backgroundColor: '#ffffff'
    },

    perfilInfo: {
        flexDirection: 'column',
        alignItems: 'center',
        justifyContent: 'space-between',
        height: 200,
    },

    perfilImg: {
        width: 309,
        // height: 267,
        height: 467,
        marginTop: 80,
    },

    username: {
        color: '#000000',
        fontFamily: 'SourceCodePro-Bold',
        fontSize: 24,
        marginBottom: -505,
    },

    role: {
        color: '#000000',
        fontFamily: 'SourceCodePro-Regular',
        fontSize: 18,
        // marginBottom: -505,
    },
    
    email: {
        color: '#000000',
        fontFamily: 'SourceCodePro-Regular',
        fontSize: 16,
        marginBottom: -1005,
    },

    emailIcon: {
        width: 30,
        height: 30,
        marginRight: 10,
    },

    emailBox: {
        height: 100,
        flexDirection: 'column',
        justifyContent: 'space-around',
        alignItems: 'center',
        
    }
});