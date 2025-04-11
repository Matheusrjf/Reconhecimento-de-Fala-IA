cv::VideoCapture cap(0);
cv::Mat frame;

while (cap.read(frame)) {
    std::vector<cv::Rect> faces = detectFaces(frame);
    
    for (auto& face : faces) {
        auto embedding = extractFaceEmbedding(frame, face);
        std::string name = recognizeFace(embedding);
        
        cv::putText(frame, name, face.tl(), cv::FONT_HERSHEY_SIMPLEX, 1, cv::Scalar(0,255,0), 2);
        cv::rectangle(frame, face, cv::Scalar(255,0,0), 2);
    }

    cv::imshow("Face Recognition", frame);
    if (cv::waitKey(1) == 27) break;
}
