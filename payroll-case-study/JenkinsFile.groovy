pipeline {
    agent any
    parameters {
        string(name: 'branch', defaultValue: 'teste', description: 'Nome da branch')
    }
    stages {
        stage('Build') {
             steps {
                echo 'Building...'
                echo 'checkout'
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
    }
}