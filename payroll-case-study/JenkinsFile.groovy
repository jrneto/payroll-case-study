pipeline {
    agent any
    parameters {
        string(name: 'branch', defaultValue: 'teste', description: 'Nome da branch')
    }
    stages {
        stage('Build') {
            
             steps {
                
                echo '########## checkout ##########'
                checkout scm

                echo '########## Restore Nuget Package ##########'
                bat "C:\\Jenkins\\workspace\\nuget.exe restore C:\\Jenkins\\workspace\\Payroll3\\payroll-case-study\\Payroll.sln"

                echo '########## Building... ##########' 
                bat "msbuild.exe C:\\Jenkins\\workspace\\Payroll3\\payroll-case-study\\Payroll.sln" 
             }

        }
        stage('Build + SonarQube analysis') {
            step {
                def sqScannerMsBuildHome = tool 'SonarScanner-MsBuild'
                withSonarQubeEnv('http://localhost:9000') {
                    // Due to SONARMSBRU-307 value of sonar.host.url and credentials should be passed on command line
                    bat "${sqScannerMsBuildHome}\\SonarQube.Scanner.MSBuild.exe begin /k:Payroll /n:Payroll /v:1.0 /d:sonar.host.url=http://localhost:9000 /d:sonar.login=bdb09369df36b21df17469fd14fc1490d88f7807"
                    bat 'MSBuild.exe /t:Rebuild'
                    bat "${sqScannerMsBuildHome}\\SonarQube.Scanner.MSBuild.exe end"
                }
            }
        }
        stage('Test') {
            steps {
                echo '########## Testing... ##########'
                bat "nunit3-console.exe C:\\Jenkins\\workspace\\Payroll3\\payroll-case-study\\Test\\bin\\Debug\\Test.dll /result=nunit-result.xml"
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
    }

    post {
        success {
            echo 'Pipeline Succeeded'
        }
        failure {
            echo 'Pipeline Failed'
        }
        unstable {
            echo 'Pipeline run marked unstable'
        }       
    }
}