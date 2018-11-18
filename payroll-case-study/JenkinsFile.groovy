pipeline {
    agent any
    parameters {
        string(name: 'branch', defaultValue: 'teste', description: 'Nome da branch')
    }
    stages {
        stage('Build') {
            
             steps {
                
                echo 'checkout'
                checkout scm

                echo 'Restore Nuget Package'
                bat "C:\\Jenkins\\workspace\\nuget.exe restore C:\\Jenkins\\workspace\\Payroll3\\payroll-case-study\\Payroll.sln"

                echo 'Building...' 
                bat "${MSBuild-default} C:\\Jenkins\\workspace\\Payroll3\\payroll-case-study\\Payroll.sln"
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