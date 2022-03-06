import React, { Component } from 'react';

import {
    SafeAreaView,
    ScrollView,
    StatusBar,
    StyleSheet,
    Text,
    Image,
    ImageBackground,
    TextInput,
    TouchableOpacity,
    View,
} from 'react-native';

import api from '../services/api';

import AsyncStorage from '@react-native-async-storage/async-storage';


export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: 'pedro.gueiros@outlook.com',
            senha: '777',
        };
    }

    realizarLogout = async () => {
        try {
            const resposta = await api.post('/login', {
                email: this.state.email,
                senha: this.state.senha,
            });

            const token = resposta.data.token;
            await AsyncStorage.setItem('userToken', token);

            if (resposta.status == 200) {
                this.props.navigation.navigate('Main');
                console.warn('Logout realizado!');
            }
        } catch {
            console.warn('Logout não foi possivel.')
        }
    };

    render() {
        return (
            <View style={styles.Login}>
                
                <Text style={styles.logoutTexto}>Tem certeza que quer encerrar a sessão?</Text>
                <TouchableOpacity
                    style={styles.btnLogin}
                    onPress={this.realizarLogout}>
                    <Text style={styles.btnLoginText}>Deslogar</Text>
                </TouchableOpacity>
            </View>
        )
    }
}

const styles = StyleSheet.create({


    Login: {
        flex: 1,
        padding: 40,
        justifyContent: 'center',
        alignItems: 'center',
        backgroundColor: '#C78989',
    },

    logoutTexto: {
        alignItems: 'center',
        fontFamily: 'SourceCodePro-Regular',
        fontSize: 24,
        color: '#000000',
    },

    btnLogin: {
        width: 200,
        height: 80,
        backgroundColor: '#D94646',
        borderRadius: 5,
        justifyContent: 'center',
        alignItems: 'center',  
        marginTop: 45,
    },

    btnLoginText: {
        fontFamily: 'SourceCodePro-Regular',
        fontSize: 24,
        color: '#000000',
    }
});