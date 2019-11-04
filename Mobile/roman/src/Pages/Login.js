import React, { Component } from 'react';
import { Text, View, TextInput, TouchableOpacity, StyleSheet, AsyncStorage } from 'react-native';

const styles = StyleSheet.create({
    signInInput: {
        fontSize: 25,
        fontFamily: 'Roboto',
        margin: 2,
        backgroundColor:'slateblue',
        color:'white'
    },
    button : {
        color: 'slateblue',
        fontSize:20,
        textAlign:'center',
        borderBottomWidth:2,
        borderBottomColor:'slateblue',
        fontWeight:'bold'
    },
    buttonContainer : {
        
    }
});

export default class Login extends Component {

    // static 

    constructor() {
        super();
        this.state = {
            userEmail: "",
            userPassword: "",
        }
    }

    _goHome = async(token) =>{
        if(token != null){
            try{
                await AsyncStorage.setItem('@gufos:token', token);
                this.props.navigation.navigate('MainNavigator');
            }
            catch(error){

            }
        }
    }

    _signIn = async () => {
        // console.warn(this.state.userEmail + this.state.userPassword)
        await fetch('http://192.168.7.85:5000/api/login', {
            method: "POST",
            headers: {
                Accept : "application/json",
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                email: this.state.userEmail,
                senha: this.state.userPassword,
            }),
        })
            .then(response => response.json())
            //sharedpreferences
            .then(data => this._goHome(data.token))
            .catch(error => console.warn(error))
    }

    render() {
        return (
            <View>
                <TextInput value = {this.state.userEmail} style={styles.signInInput} placeholder="Email" onChangeText={userEmail => this.setState({userEmail})} />
                <TextInput value = {this.state.userPassword} style={styles.signInInput} placeholder="Senha" onChangeText={userPassword => this.setState({userPassword})} />
                <TouchableOpacity onPress={this._signIn} style={styles.buttonContainer}>
                    <Text style={styles.button}>Login</Text>
                </TouchableOpacity>
            </View>
        );
    }
}