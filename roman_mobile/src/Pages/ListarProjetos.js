import React, { Component } from 'react';
import { View, Text, StyleSheet, Image } from 'react-native';
import { FlatList } from 'react-native-gesture-handler';

const styles = StyleSheet.create({
    listItem:{
        padding:5,
        fontFamily:'Roboto',
        fontSize:30
    },
    list : {
        width:'100%',
    },
    title : {
        textAlign:'center',
        fontSize:50
    }
});

export default class ListarProjetos extends Component {

    constructor(){
        super();
        this.state = {
            projetos : [],
            token : ""
        }
    }

    _getToken = async() =>{
        await this.setState({ token : AsyncStorage.getItem('@roman:token')})
    }

    _listProjetos = async() =>{
        await fetch('http://localhost:5000/api/Projetos', {
            method : "POST",
            headers:{
                Accept : "application/json",
                "Content-Type" : "application/json",
                "Authorization" : "Bearer "+this.state.token
            },
        })
        .then(response => response.json())
        .then(data => this.setState({projetos : data}))
        .catch(error => console.log(error))
    }

    componentDidMount(){
        this._getToken();
    }

    render() {
        return (
            <View>
                <Text style={styles.title}>Projetos</Text>
                <FlatList
                style = {styles.list}
                data={this.state.projetos}
                keyExtractor={item => item.idProjeto.toString()}
                    renderItem={({ item }) =>
                        (
                            <View>
                                <Text style={styles.listItem}>{item.idProjeto}</Text>
                                <Text style={styles.listItem}>{item.nome}</Text>
                                <Text style={styles.listItem}>{item.descricao}</Text>
                            </View>
                        )
                    }>

                </FlatList>
            </View>
        );
    }
}