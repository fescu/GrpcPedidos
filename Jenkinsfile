pipeline {
    agent any

    stages {

        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Restore') {
            steps {
                sh 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build --configuration Release'
            }
        }

        stage('Test') {
            steps {
                // estapa de pruebas eb construccion para siguiente entrega
                // sh 'dotnet test --no-build'
                echo "No test stage implemented."
            }
        }

        stage('Docker Build') {
            steps {
                sh 'docker compose build'
            }
        }

        stage('Docker Up') {
            steps {
                sh 'docker compose up -d'
            }
        }

        stage('Show Logs') {
            steps {
                sh 'docker ps'
            }
        }
    }

    post {
        always {
            echo "Pipeline finished."
        }
    }
}
